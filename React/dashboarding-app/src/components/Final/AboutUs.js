import React from 'react';

const AboutUs = () => {
  return (
    <div className=" min-h-screen">
      <div className="container mx-auto py-8">
        <h2 className="text-4xl font-bold mb-6 ">About Pro-XY</h2>
        <div className="flex flex-col md:flex-row">
          <div className="md:w-2/3 md:pr-8">
            <p className="mb-4 text-lg leading-relaxed">
              🚀 <strong>Welcome to Pro-XY - Your Open-Source Data Empowerment Platform!</strong>
            </p>
            <p className="mb-4 text-lg leading-relaxed">
              Every organization and department can benefit from powerful business dashboards in today’s competitive world. These essential tools help visualize the critical insights you extract from your data in an interactive and engaging way by offering centralized access to critical KPIs
            </p>
            <p className="text-lg leading-relaxed mb-4">
              State of the art business intelligence and dashboard software plays a key role in the process, as it provides the necessary features to build stunning dashboards to display crucial findings in a meaningful way. Dashboards for business can be of many types, from analytical to operational to strategic – each tracking a certain type of metrics and telling a specific data story.
            </p>
            <p className="text-lg leading-relaxed mb-4" >
              They can focus on particular department tasks and how they perform, or provide a big picture of the current status of overall activities. Working with these modern tools enhances collaboration and improves communication between your team and business units. To help you put their value into perspective, we have created a web component for different industries, functions, and platforms and that is Pro-XY
            </p>
          </div>
          <div className="md:w-1/3">
            <img src="/logo_Pro_xy_Black.png" alt="proXY" className="w-full h-auto rounded-md shadow-md" />
          </div>
        </div>
      </div>
    </div>
  );
};

export default AboutUs;
