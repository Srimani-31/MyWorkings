// The `map()` method is a higher-order function in JavaScript that allows you to apply a specified function to each element of an array. 
// It then creates a new array with the results of applying that function to each element. Here's everything you need to know about the `map()` method:

// 1. **Syntax**:

//let newArray = arr.map(callback(currentValue, index, array), thisArg);

//    - `callback`: A function that is called for each element in the array. It takes three arguments: 
//    `currentValue` (the current element being processed),
//     `index` (the index of the current element), 
//     `array` (the array `map` was called upon).

//    - `thisArg` (optional): The value to use as `this` when executing the callback function.

// 2. **Return Value**:

//    - The `map()` method creates a new array with the results of calling the provided function on every element in the calling array.

// 3. **Immutability**:

//    - The original array is not modified. `map()` returns a new array with the modified elements.

// 4. **Example Usage**:

const numbers = [1, 2, 3, 4, 5];

const doubled = numbers.map(function (num, index, array) {
   if (index % 2 === 0)
      return num * 2;
});

console.log(doubled); // Output: [2, 4, 6, 8, 10]
console.log(numbers)

const numbersArray = [1, 2, 3, 4, 5];

const modifiedArray = numbersArray.map(function (currentValue, index, array) {
   // Use currentValue, index, and array in the logic
   return currentValue * 2 + index * 10 + array.reduce((acc, num) => acc + num, 0);
});

console.log(modifiedArray);


//    In this example, `map()` is used to double each element in the `numbers` array, resulting in a new array `[2, 4, 6, 8, 10]`.

// 5. **Arrow Function Syntax**:

//    - You can also use arrow function syntax for brevity:

const numbers1 = [1, 2, 3, 4, 5];

const doubled1 = numbers1.map(num => num * 2);

console.log(doubled1); // Output: [2, 4, 6, 8, 10]

// 6. **Mapping Objects**:

//    - `map()` can also be used with arrays of objects, allowing you to transform each object according to the callback function.

const persons = [
   { name: "Alice", age: 30, height: 159 },
   { name: "Bob", age: 25, height: 160 },
   { name: "Charlie", age: 35, height: 170 }
];

const names = persons.map(person => person.name);

console.log(names); // Output: ["Alice", "Bob", "Charlie"]

// 7. **Chaining**:

//    - `map()` can be chained with other array methods to perform complex transformations.

const numbers2 = [1, 2, 3, 4, 5];

const result = numbers2
   .filter(num => num % 2 === 0)
   .map(num => num * 2);

console.log(result); // Output: [4, 8]

// 8. **Polyfill for Older Browsers**:

//    - If you're working in an environment without support for ES5 (or older), you may need to provide a polyfill for `map()`.

if (!Array.prototype.map) {
   Array.prototype.map = function (callback, thisArg) {
      // Implementation here
   };
}

// The `map()` method is a powerful tool for transforming data in arrays and is widely used in functional programming paradigms.
// It's efficient, concise, and can lead to cleaner and more expressive code.