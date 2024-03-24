import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

const Workspace = () => {
  const [dimensions, setDimensions] = useState([]);
  const [measures, setMeasures] = useState([]);
  const [selectedDimension, setSelectedDimension] = useState('');
  const [selectedMeasure, setSelectedMeasure] = useState('');
  const [userChartData, setUserChartData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const userId = '3';

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Fetch column names
        const columnResponse = await axios.get('https://localhost:44311/api/Dashboard/getColumnNames');
        const columnNames = columnResponse.data;
        setDimensions(columnNames);
        setMeasures(columnNames);

        // Fetch user chart data
        const chartResponse = await axios.get(`https://localhost:44311/api/Dashboard/getAllChartData/${userId}`);
        setUserChartData(chartResponse.data);

        setLoading(false);
      } catch (error) {
        setError(error.message || 'Error fetching data');
        setLoading(false);
      }
    };

    fetchData();
  }, [userId]);

  const handleCreateDashboard = async () => {
    try {
      const response = await axios.post(
        `https://localhost:44311/api/Dashboard/createChart/${selectedDimension}/${selectedMeasure}/${userId}`
      );
      // Handle success, maybe show a success message or update the state
    } catch (error) {
      console.error('Error creating chart:', error);
      // Handle error, show an error message
    }
  };

  if (loading) {
    return <p>Loading...</p>; // Render a loading state while data is being fetched
  }

  if (error) {
    return <p>Error: {error}</p>; // Render an error state if data fetching fails
  }

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
          {dimensions.map((dimension) => (
            <option key={dimension} value={dimension}>
              {dimension}
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
          {measures.map((measure) => (
            <option key={measure} value={measure}>
              {measure}
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

      {/* Render Bar Chart based on userChartData */}
      {userChartData.map((chartData) => (
        <div key={chartData.id} className="mt-8 p-4 border rounded">
          {console.log(chartData)}
          {selectedDimension && selectedMeasure && chartData.jsonValue ? (
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={JSON.parse(chartData.jsonValue)}>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey={selectedDimension} />
                <YAxis />
                <Tooltip />
                <Bar dataKey={selectedMeasure} fill="#5A67D8" />
              </BarChart>
            </ResponsiveContainer>
          ) : (
            <p>No data available for the selected dimension and measure.</p>
          )}
        </div>
      ))}

    </div>
  );
};

export default Workspace;