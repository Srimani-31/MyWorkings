import React, { useState, useEffect } from 'react';
import axios from 'axios';

import {
  LineChart, Line, BarChart, Bar, XAxis, YAxis, CartesianGrid,
  Tooltip, ResponsiveContainer, PieChart, Pie, Legend,
  Cell
} from 'recharts';

const colors = ['#5A67D8', '#FF6B6B', '#68D391'];
const colorsRadiaChart = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042'];
const TOTAL_SALES_API = 'https://localhost:44311/api/SampleSuperstore/getTotalSales';
const TOTAL_PROFITS_API = 'https://localhost:44311/api/SampleSuperstore/getTotalProfit';
const TOTAL_PROFITS_PERCENT_API = 'https://localhost:44311/api/SampleSuperstore/getProfitPercentage';
const REGION_SALES_API = 'https://localhost:44311/api/SampleSuperstore/getRegionSales';
const SEGMENT_SALES_API = 'https://localhost:44311/api/SampleSuperstore/getSegmentSales';
const CATEGORY_SALES_API = 'https://localhost:44311/api/SampleSuperstore/getCategorySales';
const LINE_CHART_API = 'https://localhost:44311/api/SampleSuperstore/getLineChartData';

const Landing = () => {
  const [totalSales, setTotalSales] = useState(0);
  const [totalProfits, setTotalProfits] = useState(0);
  const [totalProfitsPercentage, setTotalProfitsPercentage] = useState(0);
  const [regionSales, setRegionSales] = useState([]);
  const [segmentSales, setSegmentSales] = useState([]);
  const [categorySales, setCategorySales] = useState([]);
  const [lineChartData, setLineChartData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Fetch total sales
        const totalSalesResponse = await axios.get(TOTAL_SALES_API);
        setTotalSales(totalSalesResponse.data);

        // Fetch total profits
        const totalProfitsResponse = await axios.get(TOTAL_PROFITS_API);
        setTotalProfits(totalProfitsResponse.data);

        // Fetch total profits
        const totalProfitPercentageResponse = await axios.get(TOTAL_PROFITS_PERCENT_API);
        setTotalProfitsPercentage(totalProfitPercentageResponse.data);

        // Fetch region sales
        const regionSalesResponse = await axios.get(REGION_SALES_API);
        setRegionSales(regionSalesResponse.data);

        const segmentSalesResponse = await axios.get(SEGMENT_SALES_API);
        setSegmentSales(segmentSalesResponse.data);

        const categorySalesResponse = await axios.get(CATEGORY_SALES_API);
        setCategorySales(categorySalesResponse.data);

        const lineChartDataResponse = await axios.get(LINE_CHART_API);
        setLineChartData(lineChartDataResponse.data);

        setLoading(false); // Set loading to false once data is fetched
      } catch (error) {
        setError(error.message || 'Error fetching data');
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  return (
    <div className="container mx-auto mt-8">
      <div className="flex mb-4">
        <div className="flex-1 mx-2">
          <div className="bg-blue-200 p-4 rounded-lg shadow-md">
            <h3 className="text-lg font-bold mb-2 text-blue-800">Total Sales</h3>
            <p className="text-xl text-blue-900">&#36;{totalSales}</p>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-green-200 p-4 rounded-lg shadow-md">
            <h3 className="text-lg font-bold mb-2 text-green-800">Total Profits</h3>
            <p className="text-xl text-green-900">&#36;{totalProfits}</p>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-yellow-200 p-4 rounded-lg shadow-md">
            <h3 className="text-lg font-semibold mb-2 text-yellow-800">Total Profit %</h3>
            <p className="text-xl text-yellow-900">{totalProfitsPercentage}%</p>
          </div>
        </div>
      </div>

      <div className="flex pb-6">
        <div className="flex-1 mx-2">
          <div className="bg-gray-100 p-4 rounded-lg shadow-md">
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={regionSales} margin={{ top: 20, right: 20, left: 20, bottom: 20 }}>
                <text x="50%" y="10" textAnchor="middle" dominantBaseline="middle" fontSize={16} fontWeight="bold" fill="#333">
                  Sales by Regions
                </text>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis
                  dataKey="region"
                  type="category"
                  label={{
                    value: 'Region',
                    position: 'insideBottom',
                    offset: -10,
                    dy: 10,
                    angle: 0,
                    style: { fontSize: 12, fontWeight: 'bold' },
                  }}
                />
                <YAxis
                  type="number"
                  label={{
                    value: 'Region Sales',
                    angle: -90,
                    position: 'insideLeft',
                    dx: -15,
                    style: { fontSize: 12, fontWeight: 'bold' },
                  }}
                />
                <Tooltip formatter={(value) => `$${value}`} />
                <Bar dataKey="regionSales" fill="#5A67D8" stroke="#5A67D8" />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-gray-100 p-4 rounded-lg shadow-md">
            <ResponsiveContainer width="100%" height={300}>
              <PieChart>
                <text x="50%" y="10" textAnchor="middle" dominantBaseline="middle" fontSize={16} fontWeight="bold" fill="#333">
                  Sales by Segment
                </text>
                <Pie
                  data={segmentSales}
                  dataKey="segmentSales"
                  nameKey="segment"
                  cx="50%"
                  cy="50%"
                  outerRadius={100}
                  fill="#8884d8"
                  label
                >
                  {
                    segmentSales.map((entry, index) => (
                      <Cell key={`cell-${index}`} fill={colors[index % colors.length]} />
                    ))
                  }
                </Pie>
                <Tooltip formatter={(value) => `$${value}`} />
                <Legend />
              </PieChart>
            </ResponsiveContainer>
          </div>

        </div>
      </div>

      <div className="flex mb-4">
        <div className="flex-1 mx-2">
          <div className="bg-gray-100 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <BarChart
                data={categorySales}
                layout="vertical"
                margin={{ top: 20, right: 20, left: 20, bottom: 20 }}
              >
                <text x="50%" y="10" textAnchor="middle" dominantBaseline="middle" fontSize={16} fontWeight="bold" fill="#333">
                  Sales by Category
                </text>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis
                  type="number"
                  label={{
                    value: 'Category Sales',
                    angle: 0,
                    position: 'insideBottom',
                    offset: -10,
                    style: { fontSize: 12, fontWeight: 'bold' },
                  }}
                />
                <YAxis
                  type="category"
                  dataKey="category"
                  label={{
                    value: 'Category',
                    angle: -90,
                    position: 'insideLeft',
                    dx: -20, // Adjust the horizontal offset here
                    style: { fontSize: 12, fontWeight: 'bold' },
                  }}
                  interval={0}
                />
                <Tooltip formatter={(value) => `$${value}`} />
                <Bar dataKey="categorySales" fill="#5A67D8" />
              </BarChart>
            </ResponsiveContainer>

          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-gray-100 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <LineChart data={lineChartData}>
                <text x="50%" y="10" textAnchor="middle" dominantBaseline="middle" fontSize={16} fontWeight="bold" fill="#333">
                  Sales by Shipmodes
                </text>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="shipMode" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Line type="monotone" dataKey="shipModeSales" stroke="#8884d8" />
              </LineChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Landing;
