# Dynamic Programming - C#

Main References:

- http://alg1.elte.hu/
- https://www.youtube.com/watch?v=oBt53YbR9Kk

<br>

## Fibonacci

```cs
int Fib(int n){
    if(n <= 2) return 1;
    return Fib(n-1) + Fib(n-2);
}

System.Console.WriteLine(Fib(46));
```

### Fibonacci - Memo

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

long GridTraveler(long n, long m, Dictionary<string, long> memo)
{
    string key = n + ":" + m;
    if(memo.ContainsKey(key)) return memo[key];

    if(n == 1 && m == 1) return 1;
    if(n == 0 || m == 0) return 0;

    memo[key] = GridTraveler(n-1, m, memo) + GridTraveler(n, m-1, memo);

    return memo[key];
}

System.Console.WriteLine(GridTraveler(18,18, new Dictionary<string, long>()));
```

<br>

## LCS - Longest Common Sebsequence - Memo

Similar problems:
- Total Unique Ways To Make Change - Memo

```cs
int Max(int a, int b)
{
    return a >= b ? a : b;
}

int LCS(char[] x, char[] y, int n, int m)
{
    int[,] memo = new int[n + 1, m + 1];

    for(int i = 0; i <= n; i++){
        for(int j = 0; j <= m; j++){
            if(i == 0 || j == 0){
                memo[i, j] = 0;
            }
            else if(x[i - 1] == y[j - 1]){
                memo[i, j] = memo[i-1, j-1] + 1;
            }
            else{
                memo[i, j] = Max(memo[i, j-1], memo[i-1, j]);
            }
        }
    }

    return memo[n, m];
}

string s1 = "ALMA";
string s2 = "KALAP";
int n = s1.Length;
int m = s2.Length;
System.Console.WriteLine(LCS( s1.ToCharArray(), s2.ToCharArray(), n, m)); // => 3
```

<br>

## Coin change problems

References:
- http://alg1.elte.hu/
- https://www.youtube.com/watch?v=jgiZlGzXMBw
- https://www.youtube.com/watch?v=DJ4a7cmjZY0

### Fewest Coin To Make Change - Memo

#### Input:

```cs
coins = [1, 2, 3]
goal = 10
------------------------
solution: 5 + 5 + 1 = 11
```

Top Down approach:

```cs
           11
/+1(-1)    |+1(-2)   \+1(-5)  
10          9          6
                   /   |   \
                  5    4    1
                              \
                               0
```

```cs
using System;

int LeastCoin(int[] coins, int amount)
{
    if(amount < 1) return 0;
    return FewestCoinChange(coins, amount, new int[amount + 1]);
}

int FewestCoinChange(int[] coins, int remainder, int[] dp)
{
    if(remainder < 0) return -1;
    if(remainder == 0) return 0;
    if(dp[remainder] != 0) return dp[remainder];

    int min = Int32.MaxValue;
    foreach(int coin in coins)
    {
        int changeResult = FewestCoinChange(coins, remainder - coin, dp);
        if(changeResult < min && changeResult >= 0){
            min = 1;
            min += changeResult;
        }
    }

    dp[remainder] = (min == Int32.MaxValue) ? -1 : min;
    return dp[remainder];
}

int[] coins = new int[]{1, 2, 3};
int goal = 10;
System.Console.WriteLine( LeastCoin(coins, goal)); // 4

coins = new int[]{1, 3, 5, 6, 9};
goal = 90;
System.Console.WriteLine( LeastCoin(coins, goal)); // 10
```

### Total Unique Ways To Make Change - Memo

Similar problems:
- Longest Common Sebsequence - Memo

#### Input:

```cs
coins = [1, 2, 5]
amount = 5
------------------------
result = 4
```

| coins | 0 | 1 | 2 | 3 | 4 | 5
| ----  | - | - | - | - | - | -
| `[ ]`       | 1 | 0 | 0 | 0 | 0 | 0
| `[1]`       | 1 | 1 | 1 | 1 | 1 | 1
| `[(1),2]`   | 1 | 1 | 2 | 2 | 3 | 3
| `[(1,2),5]` | 1 | 1 | 2 | 2 | 3 | [4]


```cs
long TotalCoinChange(long[] coins, long amount)
{
    if(amount < 1) return 0;
    long n = coins.Length;
    long m = amount;
    long[,] memo = new long[n + 1, m + 1];

    memo[0, 0] = 1;
    for(int i = 1; i <= n; i++)
    {
        memo[i, 0] = 1;
        long coin = coins[i - 1];
        for(int j = 1; j <= m; j++){
            memo[i, j] = memo[i-1, j] + (j >= coin ? memo[i, j - coin] : 0);
        }
    }

    return memo[n, m];
}

System.Console.WriteLine( TotalCoinChange(new long[]{1,2,5}, 5) ); // 4
```
Time: `O(amount * #coins)` <br>
Space: `O(amount * #coins)`



<br>
<br>
<br>
<br>
<br>