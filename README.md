# Steps
* Define Subproblems
* Guess(part of the solution that can be solved in polynomial time)
* Establish a recurrence relation (will help you establish time per sub problem)
* Recurse and memoise [this can be solved in a bottom up approach]
	- Check if it is acyclic (if so use topological ordering)
	- total running time = number of subproblems * time per subproblem
* Solve the original problem
