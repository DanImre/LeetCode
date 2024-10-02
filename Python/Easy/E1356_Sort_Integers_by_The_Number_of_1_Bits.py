import queue


class Solution:
    def getValue(self, item: int):
        return bin(item).count("1") * 100000 + item

    def sortByBits(self, arr: list[int]) -> list[int]:
        prq = queue.PriorityQueue()
        for item in arr:
            prq.put((self.getValue(item), item))

        for i in range(0, len(arr)):
            arr[i] = prq.get()[1]

        return arr
