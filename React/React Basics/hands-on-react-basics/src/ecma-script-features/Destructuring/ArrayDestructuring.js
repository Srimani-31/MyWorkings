// To illustrate destructuring, we'll make a sandwich. Do you take everything out of the refrigerator to make your sandwich? 
// No, you only take out the items you would like to use on your sandwich.

// Destructuring is exactly the same. We may have an array or object that we are working with,
//  but we only need some of the items contained in these.

// Destructuring makes it easy to extract only what is needed.


const nums = ['srimani', 'suresh', 'nirmal', 'naveen', 'priya']

//how do we assign the array element to the variable
//old way

const p1 = nums[0]
const p2 = nums[1]
const p3 = nums[2]
const p4 = nums[3]
const p5 = nums[4]

//new way

const [p_1,p_2,p_3,p_4,p_5] = nums

console.log(p_1)

//skipping the element

const [p__1,p__2,p__3,,p__5] = nums
console.log(`skipping the ${nums[3]}`);
console.log(p__1, p__2, p__3, p__5)

