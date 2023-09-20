//idea of object destructuring 
//converting an object or an array into smaller object / smaller components

const alphabet = ['A', 'B', 'C', 'D', 'E', 'F']
const numbers = ['1', '2', '3', '4', '5', '6']

//without destructuring
//getting first two elements
// const a = alphabet[0]
// const b = alphabet[1]

const [a,b] = alphabet
console.log(a) // A
console.log(b) // B

// skipping an Element
const [a1,,c1] = alphabet
console.log(a1) // A
console.log(c1) // C

//spread operator
const [a2,,c2, ...rest] = alphabet
console.log(a2) // A
console.log(c2) // C
console.log(rest) // (3) ["D", "E", "F"]


//combing two array using object destructuring
const newArray = [...alphabet,...numbers]