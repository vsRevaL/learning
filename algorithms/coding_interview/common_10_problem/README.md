# 10 Common Coding Interview Problems - Solved!

## Reference: https://youtu.be/Peq4GCPNC5c

## Valid Anagram

### Use Hash Table

```py
def are_anagrams(s1, s2):
    if len(s1) != len(s2):
        return False
    map1 = {}
    map2 = {}
    for ch in s1:
        if ch in map1:
            map1[ch] += 1
        else:
            map1[ch] = 1

        if ch in map2:
            map2[ch] += 1
        else:
            map2[ch] = 1

    for key in map1:
        if key not in map2 or map2[key] != map2[key]:
            return False
    return True


print(are_anagrams("asd", "sad"))
```

```py
def are_anagrams(s1, s2):
    if len(s1) != len(s2):
        return False
    return sorted(s1) == sorted(s2)


print(are_anagrams("asd", "sad"))
```

## First and last index in sorted array

Given a sorted array of intigers `arr` and an integer `target`, find the index of the first and last position of `target` in `arr`.
If target can't be found in arr, return `[-1, -1]`

`O(n)`

```py
def first_and_last(arr, target):
    for i in range(len(arr)):
        if arr[i] == target:
            start = i
            while i < len(arr) and arr[i] == target:
                i += 1
            return [start, i - 1]
    return [-1, -1]


print(first_and_last([2, 4, 5, 5, 5, 5, 5, 7, 9, 9], 5))
```

`O(logn)`

```py
def find_first(arr, target, start, end):
    while start <= end:
        mid = (start + end) // 2
        if arr[mid] == target and (mid == 0 or arr[mid - 1] != target):
            return mid
        elif arr[mid] >= target:
            end = mid - 1
        else:
            start = mid + 1
    return -1


def find_last(arr, target, start, end):
    while start <= end:
        mid = (start + end) // 2
        if arr[mid] == target and (mid == len(arr) - 1 or arr[mid + 1] != target):
            return mid
        elif arr[mid] <= target:
            start = mid + 1
        else:
            end = mid - 1
    return -1


def first_and_last(arr, target):
    first = find_first(arr, target, 0, len(arr) - 1)
    last = find_last(arr, target, 0, len(arr) - 1)
    print(str(first) + " " + str(last))


first_and_last([2, 4, 5, 5, 5, 5, 5, 7, 9, 9], 5)
```

## Kth largest element - using heap

```py
import heapq


def kth_largest(arr, k):
    arr = [-elem for elem in arr]
    heapq.heapify(arr)
    for i in range(k):
        heapq.heappop(arr)
    return -heapq.heappop(arr)


print(kth_largest([4, 2, 9, 7, 5, 6, 7, 1, 3], 4))
```

## Symmetric tree

### py

```py
```

### C# with test data

```cs
class Node
{
    public int val;
    public Node left;
    public Node right;

    public Node(int val)
    {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

class Program
{
    static bool AreSymmetric(Node root1, Node root2)
    {
        if (root1 == null && root2 == null) return true;
        else if ((root1 == null) != (root2 == null) || root1.val != root2.val) return false;
        else return AreSymmetric(root1.left, root2.right) && AreSymmetric(root1.right, root2.left);
    }

    static bool IsSymmetric(Node root)
    {
        if (root == null) return true;
        return AreSymmetric(root.left, root.right);
    }

    static void Main()
    {
        Node root = new Node(2);
        Node n1 = new Node(9);
        Node n2 = new Node(9);
        root.left = n1;
        root.right = n2;

        Node n3 = new Node(3);
        Node n4 = new Node(3);
        Node n5 = new Node(0);
        Node n6 = new Node(0);
        n1.left = n3;
        n1.right = n6;
        n2.left = n5;
        n2.right = n4;

        Console.WriteLine(IsSymmetric(root));
    }
}

```

<br>
<br>
<br>
<br>