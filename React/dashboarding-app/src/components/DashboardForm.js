import React, { useState, useEffect } from 'react';
import axios from 'axios';

const DashboardForm = ({ onFormSubmit }) => {
  const [dimensions, setDimensions] = useState([]);
  const [measures, setMeasures] = useState([]);

  const userId = '3'

  useEffect(() => {
    // Fetch dimensions and measures from API using Axios
    const fetchData = async () => {
      try {
        const response = await axios.get('https://localhost:44311/api/Dashboard/getColumnNames');
        const data = response.data;

        // Assuming the first half of the data is dimensions and the second half is measures
        const halfLength = Math.ceil(data.length / 2);
        const dimensionsData = data.slice(0, halfLength);
        const measuresData = data.slice(halfLength);

        setDimensions(dimensionsData);
        setMeasures(measuresData);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    // Assuming you want to do something with selected dimensions and measures
    onFormSubmit({ dimensions, measures });
  };

  return (
    <form onSubmit={handleSubmit} className="p-4 bg-gray-100 rounded shadow-md">
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">Dimension:</label>
        <select
          className="block w-full p-2 border rounded focus:outline-none focus:border-blue-500"
        >
          {dimensions.map((dimension, index) => (
            <option key={index} value={dimension}>
              {dimension}
            </option>
          ))}
        </select>
      </div>
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">Measure:</label>
        <select
          className="block w-full p-2 border rounded focus:outline-none focus:border-blue-500"
        >
          {measures.map((measure, index) => (
            <option key={index} value={measure}>
              {measure}
            </option>
          ))}
        </select>
      </div>
      <div>
        <button
          type="submit"
          className="bg-blue-500 text-white p-2 rounded hover:bg-blue-700 focus:outline-none focus:shadow-outline-blue"
        >
          Create Dashboard
        </button>
      </div>
    </form>
  );
};

export default DashboardForm;
