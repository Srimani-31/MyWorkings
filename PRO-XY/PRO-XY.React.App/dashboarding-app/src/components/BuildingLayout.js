// Import React and necessary components
import React from 'react';

// Import Tailwind CSS styles
import 'tailwindcss/tailwind.css';
import axios from 'axios';


import {
  AreaChart, Area, LineChart, Line, BarChart, Bar, XAxis, YAxis, CartesianGrid,
  Tooltip, ResponsiveContainer, PieChart, Pie, Legend, ScatterChart, Scatter,
  RadarChart, PolarGrid, PolarAngleAxis, PolarRadiusAxis, ComposedChart, Cell,Radar
} from 'recharts';

// Define different colors for each portion

const colors = ['#5A67D8', '#FF6B6B', '#68D391', '#F6E05E', '#A0AEC0'];

const data = [
  { name: 'Jan', value: 30, amt: 2400 },
  { name: 'Feb', value: 45, amt: 2210 },
  { name: 'Mar', value: 28, amt: 2290 },
  { name: 'Apr', value: 60, amt: 2000 },
  { name: 'May', value: 38, amt: 2181 },
];

const scatterData = [
  { x: 10, y: 30 },
  { x: 30, y: 200 },
  { x: 45, y: 100 },
  { x: 50, y: 250 },
];

const radarData = [
  { subject: 'Math', A: 120, B: 110, fullMark: 150 },
  { subject: 'English', A: 98, B: 130, fullMark: 150 },
  { subject: 'Physics', A: 86, B: 130, fullMark: 150 },
  { subject: 'History', A: 99, B: 100, fullMark: 150 },
  { subject: 'Geography', A: 85, B: 90, fullMark: 150 },
  { subject: 'Chinese', A: 65, B: 85, fullMark: 150 },
];

// Calculate total sales, total profits, and total profit percentage
const totalSales = data.reduce((sum, { value }) => sum + value, 0);
const totalProfits = data.reduce((sum, { amt }) => sum + amt, 0);

// Define the main component
const BuildingLayout = () => {
  return (
    <div className="container mx-auto mt-8">
      {/* Widgets for Total Sales, Total Profits, and Total Profit Percentage */}
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
            <p className="text-xl text-yellow-900">12%</p>
          </div>
        </div>
      </div>

      {/* Third Row */}
      <div className="flex pb-6">
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <BarChart layout="vertical" data={data} margin={{ left: 20 }}>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis type="number" />
                <YAxis dataKey="name" type="category" />
                <Tooltip />
                <Bar dataKey="value" fill="#5A67D8" />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <AreaChart data={data}>
                <Area type="monotone" dataKey="value" stroke="#FF6B6B" fill="#FF6B6B" />
                <Tooltip />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>

      {/* Second Row */}
      <div className="flex mb-4">
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <PieChart>
                <Pie
                  data={data}
                  dataKey="value"
                  nameKey="name"
                  cx="50%"
                  cy="50%"
                  outerRadius={100}
                  fill="#8884d8"
                  label
                >
                  {
                    data.map((entry, index) => (
                      <Cell key={`cell-${index}`} fill={colors[index % colors.length]} />
                    ))
                  }
                </Pie>
                <Legend />
                <Tooltip />
              </PieChart>
            </ResponsiveContainer>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <LineChart data={data} style={{ background: '#f0f0f0' }}>
                <Line type="monotone" dataKey="value" stroke="#FF6B6B" strokeWidth={2} />
                <Tooltip contentStyle={{ backgroundColor: '#333', color: '#fff' }} />
              </LineChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>

      {/* First Row */}
      <div className="flex mb-4">
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <ScatterChart>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis type="number" dataKey="x" name="X" stroke="#5A67D8" strokeWidth={2} />
                <YAxis type="number" dataKey="y" name="Y" stroke="#5A67D8" strokeWidth={2} />
                <Tooltip cursor={{ strokeDasharray: '3 3' }} />
                <Scatter data={scatterData} fill="#5A67D8" />
              </ScatterChart>

            </ResponsiveContainer>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <RadarChart outerRadius={90} width={400} height={300} data={radarData}>
                <PolarGrid />
                <PolarAngleAxis dataKey="subject" />
                <PolarRadiusAxis angle={30} domain={[0, 150]} />
                <Radar name="A" dataKey="A" stroke="#5A67D8" fill="#5A67D8" fillOpacity={0.6} strokeWidth={2} />
                <Radar name="B" dataKey="B" stroke="#FF7E67" fill="#FF7E67" fillOpacity={0.6} strokeWidth={2} />
                <Tooltip />
              </RadarChart>

            </ResponsiveContainer>
          </div>
        </div>
        <div className="flex-1 mx-2">
          <div className="bg-gray-300 p-4 rounded-lg">
            <ResponsiveContainer width="100%" height={300}>
              <ComposedChart width={400} height={300} data={data}>
                <Bar dataKey="value" fill="#5A67D8" />
                <Line type="monotone" dataKey="amt" stroke="#FF6B6B" />
                <Tooltip />
              </ComposedChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>
    </div>
  );
};

// Export the component
export default BuildingLayout;
