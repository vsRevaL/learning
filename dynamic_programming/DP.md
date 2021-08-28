# Dynamic Programming - C#

Main References:

- https://www.youtube.com/watch?v=oBt53YbR9Kk

## Fibonacci

```cs
int Fib(int n){
    if(n <= 2) return 1;
    return Fib(n-1) + Fib(n-2);
}

System.Console.WriteLine(Fib(46));
```

## Fibonacci - Memo

```cs
using System.Collections.Generic;

long Fib(long n, Dictionary<long, long> memo){
    if(memo.ContainsKey(n)) return memo[n];
    if(n <= 2) return 1;
    memo[n] = Fib(n-1, memo) + Fib(n-2, memo);
    return memo[n];
}

System.Console.WriteLine(Fib(150, new Dictionary<long, long>()));
```

<br>

## Grid Traveler Problem - Memo

You are a traveler on a 2D grid. You begin in the top-left corner and your goal is to travel to the bottom-right corner. You may only move down or right.

How many ways can you travel to the goal on a grid with dimensions `m * n`?

```cs
using System.Collections.Generic;

long GridTraveler(long n, long m, Dictionary<string, long> memo){
    string key = n + ":" + m;
    if(memo.ContainsKey(key)) return memo[key];

    if(n == 1 && m == 1) return 1;
    if(n == 0 || m == 0) return 0;

    memo[key] = GridTraveler(n-1,m, memo) + GridTraveler(n,m-1,memo);

    return memo[key];
}

System.Console.WriteLine(GridTraveler(18,18, new Dictionary<string, long>()));
```

## LCS - Longest Common Sebsequence - Memo

```cs
int max(int a, int b){

    return a >= b ? a : b;
}

int lcs(char[] x, char[] y, int n, int m){

    int[,] memo = new int[n + 1, m + 1];

    for(int i = 0; i <= n; i++){
        for(int j = 0; j <= m; j++){
            if(i == 0 || j == 0){
                memo[i, j] = 0;
            }
            else if(x[i - 1] == y[j - 1]){
                memo[i,j] = memo[i-1, j-1] + 1;
            }
            else{
                memo[i,j] = max(memo[i,j-1], memo[i-1,j]);
            }
        }
    }

    return memo[n, m];
}

string s1 = "ALMA";
string s2 = "KALAP";
int n = s1.Length;
int m = s2.Length;
System.Console.WriteLine(lcs( s1.ToCharArray(), s2.ToCharArray(), n, m)); // => 3
```

<br>
<br>
<br>
<br>
<br>