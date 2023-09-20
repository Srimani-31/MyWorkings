// JavaScript modules allow you to break up your code into separate files.

// This makes it easier to maintain the code-base.

// ES Modules rely on the import and export statements.

// Export
// You can export a function or variable from any file.

// Let us create a file named person.js, and fill it with the things we want to export.

// There are two types of exports: Named and Default.


import PI  from './NamedExport.mjs';
// import DefaultExport from './DefaultExport.mjs'
// import { SayHiViaDefaultExport } from './DefaultExport.mjs'

console.log(`Named exports demo ${PI}`)
console.log('Default export demo ')
//DefaultExport()

console.log('Exporting the named export from the default export module')
//SayHiViaDefaultExport()




