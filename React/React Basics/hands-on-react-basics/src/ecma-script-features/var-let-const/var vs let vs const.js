// In JavaScript, `var`, `let`, and `const` are used for variable declarations, but they have different behaviors and scopes. Here's an explanation of each:

// 1. **`var`**:
//    - `var` was historically the way to declare variables in JavaScript before ES6 (ES2015).
//    - Variables declared with `var` are function-scoped, meaning they are limited in scope to the nearest function in which they are declared.
//    - If a `var` variable is declared outside of any function, it becomes a global variable.
//    - `var` variables are hoisted to the top of their containing function or global scope, which means you can use them before they are declared (although this is generally considered bad practice).

   function example() {
     var x = 10;
     if (true) {
       var y = 20;
     }
     console.log(x); // 10
     console.log(y); // 20 (y is accessible outside the block)
   }

// 2. **`let`**:
//    - `let` was introduced in ES6 (ES2015) to address some of the issues with `var`.
//    - Variables declared with `let` are block-scoped, meaning they are limited in scope to the nearest enclosing block (a block is typically defined by curly braces `{}`).
//    - `let` variables are not hoisted to the top of their containing block, so you cannot use them before they are declared.

   function example() {
     let x = 10;
     if (true) {
       let y = 20;
     }
     console.log(x); // 10
     console.log(y); // ReferenceError: y is not defined
   }

// 3. **`const`**:
//    - `const` is also introduced in ES6.
//    - Variables declared with `const` are block-scoped, just like `let`.
//    - However, `const` variables cannot be reassigned after they are declared. They are meant for values that should remain constant.
//    - Like `let`, `const` variables are not hoisted, and you cannot use them before they are declared.

   function example() {
     const x = 10;
     if (true) {
       const y = 20;
     }
     console.log(x); // 10
     console.log(y); // ReferenceError: y is not defined
   }

// In practice, it's a good practice to use `const` by default when declaring variables, especially for values that should not be reassigned. 
// Use `let` when you need to reassign a variable's value, and 
// avoid using `var` in modern JavaScript, as it has some quirks and 
// is generally less predictable than `let` and `const`. This helps improve code clarity and avoid unexpected behavior in your programs.