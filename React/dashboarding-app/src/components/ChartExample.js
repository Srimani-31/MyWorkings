import React from 'react';
import { LineChart, Line, AreaChart, Area, BarChart, Bar, ComposedChart, PieChart, Pie, ScatterChart, Scatter, RadarChart, PolarGrid, PolarAngleAxis, PolarRadiusAxis, RadialBarChart, RadialBar, Treemap, Tooltip, Legend } from 'recharts';

const data = [
  { name: 'Jan', value: 30, amt: 2400 },
  { name: 'Feb', value: 45, amt: 2210 },
  { name: 'Mar', value: 28, amt: 2290 },
  { name: 'Apr', value: 60, amt: 2000 },
  { name: 'May', value: 38, amt: 2181 },
];

const pieData = [
  { name: 'Category A', value: 200 },
  { name: 'Category B', value: 150 },
  { name: 'Category C', value: 100 },
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

const radialBarData = [
  { name: 'Category A', uv: 31.47, pv: 2400, fill: '#8884d8' },
  { name: 'Category B', uv: 26.69, pv: 4567, fill: '#83a6ed' },
  { name: 'Category C', uv: 15.69, pv: 1398, fill: '#8dd1e1' },
];

const treemapData = {
  name: 'root',
  children: [
    { name: 'Category A', size: 1000 },
    { name: 'Category B', size: 500 },
    { name: 'Category C', size: 300 },
  ],
};

const ChartsExample = () => {
  return (
    <div>
      <h2>Line Chart</h2>
      <LineChart width={400} height={300} data={data}>
        <Line type="monotone" dataKey="value" stroke="#8884d8" />
        <Tooltip />
      </LineChart>

      <h2>Area Chart</h2>
      <AreaChart width={400} height={300} data={data}>
        <Area type="monotone" dataKey="value" stroke="#8884d8" fill="#8884d8" />
        <Tooltip />
      </AreaChart>

      <h2>Bar Chart</h2>
      <BarChart width={400} height={300} data={data}>
        <Bar dataKey="value" fill="8884d8"  />
        <Tooltip />
      </BarChart>

      <h2>Composed Chart</h2>
      <ComposedChart width={400} height={300} data={data}>
        <Bar dataKey="value" fill="#8884d8" />
        <Line type="monotone" dataKey="amt" stroke="#82ca9d" />
        <Tooltip />
      </ComposedChart>

      <h2>Pie Chart</h2>
      <PieChart width={400} height={300}>
        <Pie data={pieData} dataKey="value" nameKey="name" cx="50%" cy="50%" outerRadius={80} fill="#8884d8" label />
        <Legend />
        <Tooltip />
      </PieChart>

      <h2>Scatter Chart</h2>
      <ScatterChart width={400} height={300}>
        <Scatter data={scatterData} fill="#8884d8" />
        <Tooltip cursor={{ strokeDasharray: '3 3' }} />
      </ScatterChart>

      <h2>Radar Chart</h2>
      <RadarChart outerRadius={90} width={400} height={300} data={radarData}>
        <PolarGrid />
        <PolarAngleAxis dataKey="subject" />
        <PolarRadiusAxis angle={30} domain={[0, 150]} />
        <Tooltip />
      </RadarChart>

      <h2>Radial Bar Chart</h2>
      <RadialBarChart width={400} height={300} innerRadius="20%" outerRadius="80%" data={radialBarData}>
        <RadialBar startAngle={90} endAngle={-270} minAngle={15} label={{ position: 'insideStart', fill: '#fff' }} background clockWise={true} dataKey="uv" />
        <Legend iconSize={10} width={120} height={140} layout="vertical" verticalAlign="middle" align="right" />
        <Tooltip />
      </RadialBarChart>

      <h2>Treemap</h2>
      <Treemap width={400} height={300} data={treemapData} dataKey="size" ratio={4 / 3} stroke="#fff" fill="#8884d8" />
    </div>
  );
};

export default ChartsExample;
