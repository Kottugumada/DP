##### One way to define subproblems for Strings
* **Suffixes x[i:]** slice of i till end of the string	[Can be solved in linear time]   
* **Prefixes x[:j]** slice of everything from the begining of the string [Can be solved in linear time]   
* **Substrings x[i:j]** (where i<=j) [Can be solved in O(n^2) time (mostly becuase we might need two pointers)]



(As a rule of thumb we never need prefixes and suffixes together)

Substrings would be in increasing size of the string

#### Edit distance
##### Longest Common Subsequence e.g.
    hieroglyphology
	michaelangelo

**Step 1:** Define Subproblem:
Edit distance on two different substrings 
x[i:] and another string y[j:]
So, number of subproblems becomes length of x times length of y. All teh characters of x times all the characters of y.
Quadratic time O(n^2)

**Step 2:** Guess the smallest part of the solution that can be solved in polynomial time
	Three possibilities:
	*Insert 
	*Delete and
	*Replace

**Step 3:** Establish Recurrence Relation
DP(i,j) = MIN(
	*1. (Cost of insert y[i]) + DP(i,j+1)
	*2. (Cost of delete x[i]) + DP(i+1,j)
	*3. (Cost of replace x[i] -> y[i]) + DP(i+1,j+1)
	)

	Insert delete or replace, whichever is cheaper

**Step 4:** Topological ordering
for(i: x....0)
	for(j: y....0)

Each cell is a node in the dp matrix and we check the adjacent cells
Bottom up in a DAG, Weight of an edge is the cost of an operation	


**Step 5:** Original problem:
DP(0,0) that is the upper left top corner in the DAG

<table>
	<tr>
		<td>Current Cell (i,j)</td>
		<td>Insert(i,j+1)</td>
	</tr>
	<tr>
		<td>Delete(i+1,j)</td>
		<td>Replace(i+1,j+1)</td>
	</tr>
</table>



![DP](https://i.imgur.com/bQjsf1J.png)
	
