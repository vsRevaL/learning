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

### O(n)

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

<br>
<br>
<br>
<br>