https://www.includehelp.com/dot-net/insert-an-element-at-given-position-into-array-using-c-sharp-program.aspx

[
	{ lastName: 'Aaaa', firstName: 'Aaaa', age: 20, id: 3 },
	{ lastName: 'Aaaa', firstName: 'Bbbb', age: 56, id: 2 },
	{ lastName: 'Cccc', firstName: 'Aaaa', age: 32, id: 5 },
	{ lastName: 'Cccc', firstName: 'Bbbb', age: 50, id: 1 },
	{ lastName: 'Dddd', firstName: 'Aaaa', age: 70, id: 4 },
]

POST
[{ lastName: 'Bbbb', firstName: 'Bbbb', age: 26, id: 6 }]	->  

Array after insert
[
	{ lastName: 'Aaaa', firstName: 'Aaaa', age: 20, id: 3 },
	{ lastName: 'Aaaa', firstName: 'Bbbb', age: 56, id: 2 },
																{ lastName: 'Bbbb', firstName: 'Bbbb', age: 26, id: 6 }, -> here
	{ lastName: 'Cccc', firstName: 'Aaaa', age: 32, id: 5 },
	{ lastName: 'Cccc', firstName: 'Bbbb', age: 50, id: 1 },
	{ lastName: 'Dddd', firstName: 'Aaaa', age: 70, id: 4 },
]

POST
[{ lastName: 'Bbbb', firstName: 'Aaaa', age: 28, id: 7 }]

Array after insert
[
	{ lastName: 'Aaaa', firstName: 'Aaaa', age: 20, id: 3 },
	{ lastName: 'Aaaa', firstName: 'Bbbb', age: 56, id: 2 },
	{ lastName: 'Bbbb', firstName: 'Aaaa', age: 28, id: 7 }, -> here
	{ lastName: 'Bbbb', firstName: 'Bbbb', age: 26, id: 6 },
	{ lastName: 'Cccc', firstName: 'Aaaa', age: 32, id: 5 },
	{ lastName: 'Cccc', firstName: 'Bbbb', age: 50, id: 1 },
	{ lastName: 'Dddd', firstName: 'Aaaa', age: 70, id: 4 },
]

//
request customers.Count > 1 => asc lastname, firstname

// Database with Customers
	// in memory table: string with array that get updated every POST customers
// method -> on server upload: fill an array with Customers objects which stays in the memory
// new customers in post request, each customer inserts at position that does not break the sortion of the array