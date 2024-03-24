import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

const ChartCreation = (props) => {
  const [columns, setColumns] = useState([]);
  const [selectedDimension, setSelectedDimension] = useState('');
  const [selectedMeasure, setSelectedMeasure] = useState('');
  const [userChartData, setUserChartData] = useState([]);
  const [loadingColumns, setLoadingColumns] = useState(true);
  const [loadingChartData, setLoadingChartData] = useState(false);
  const [error, setError] = useState(null);

  const userId = '3';

  const validateChartData = (data) => {
    if (!Array.isArray(data) || data.length === 0) {
      setError('Invalid data format. Please check the data.');
      return false;
    }

    if (!data[0].hasOwnProperty(selectedDimension) || !data[0].hasOwnProperty(selectedMeasure)) {
      setError('Selected dimension or measure not found in the data.');
      return false;
    }

    return true;
  };

  useEffect(() => {
    const fetchData = async () => {
      const errorHandled = { current: false }; // Create a ref to track whether the error has been handled

      try {
        // Fetch column names
        const columnResponse = await axios.get('https://localhost:44311/api/Dashboard/getColumnNames');
        const columnNames = columnResponse.data;
        setColumns(columnNames);

        setLoadingColumns(false);  // Set loadingColumns to false after fetching columns
      } catch (error) {
        if (!errorHandled.current) {
          setError(error.message || 'Error fetching column names');
          setLoadingColumns(false);
          errorHandled.current = true; // Set a ref to true to indicate that the error has been handled
        }
      }
    };

    fetchData();
  }, []); // Empty dependency array to fetch column names only once

  const handleCreateDashboard = async () => {
    try {
      if (selectedDimension && selectedMeasure) {
        setLoadingChartData(true); // Set loadingChartData to true before making the API call

        // Fetch updated chart data
        const chartResponse = await axios.get(`https://localhost:44311/api/Dashboard/getChartData/${selectedDimension}/${selectedMeasure}/${userId}`);
        const newChartData = chartResponse.data;

        if (validateChartData(newChartData)) {
          setUserChartData(newChartData);
          setError(null); // Reset error if validation passes

          // Raise the event here, you can pass data or trigger specific actions
          if (props.onCreateDashboard) {
            props.onCreateDashboard({
              selectedDimension,
              selectedMeasure,
              userChartData: newChartData,
            });
          }
        }
      } else {
        setError('Please select both a dimension and a measure.');
      }
    } catch (error) {
      console.error('Error creating chart:', error);
      setError('Error creating chart');
    } finally {
      setLoadingChartData(false); // Set loadingChartData to false after API call, whether it succeeds or fails
    }
  };

  return (
    <div className="container mx-auto mt-8">
      <div className="mb-4">
        <label htmlFor="dimension" className="block text-sm font-bold text-gray-700">
          Dimension:
        </label>
        <select
          id="dimension"
          value={selectedDimension}
          onChange={(e) => setSelectedDimension(e.target.value)}
          className="w-full mt-2 p-2 border rounded"
        >
          <option value="">Select Dimension</option>
          {columns.map((column) => (
            <option key={column} value={column}>
              {column}
            </option>
          ))}
        </select>
      </div>

      <div className="mb-4">
        <label htmlFor="measure" className="block text-sm font-bold text-gray-700">
          Measure:
        </label>
        <select
          id="measure"
          value={selectedMeasure}
          onChange={(e) => setSelectedMeasure(e.target.value)}
          className="w-full mt-2 p-2 border rounded"
        >
          <option value="">Select Measure</option>
          {columns.map((column) => (
            <option key={column} value={column}>
              {column}
            </option>
          ))}
        </select>
      </div>

      <button
        onClick={handleCreateDashboard}
        className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-700"
      >
        Create Dashboard
      </button>

      {/* Render Chart */}
      {loadingColumns && <p>Loading column names...</p>}
      {loadingChartData && <p>Loading chart data...</p>}
      {error && <p>{error}</p>}
      {selectedDimension && selectedMeasure && validateChartData(userChartData) && (
        <div className="mt-8 p-4 border rounded">
          <ResponsiveContainer width="100%" height={300}>
            <BarChart data={userChartData}>
              <CartesianGrid strokeDasharray="3 3" />
              <XAxis dataKey={selectedDimension} />
              <YAxis />
              <Tooltip />
              <Bar dataKey={selectedMeasure} fill="#5A67D8" />
            </BarChart>
          </ResponsiveContainer>
        </div>
      )}
    </div>
  );
};

export default ChartCreation;
