class Solution:
    def fullBloomFlowers(self, flowers: list[list[int]], people: list[int]) -> list[int]:
        solution = []

        flowers = sorted(flowers, key=lambda x: x[0])
        for item in people:
            solution.append(self.BinarySearch(0, item, flowers))

        flowers = sorted(flowers, key=lambda x: x[1])
        for i in range(0, len(people)):
            solution[i] -= self.BinarySearch(1, people[i] - 1, flowers)

        return solution

    def BinarySearch(self, whichOne: int, target: int, flowers: list[list[int]]) -> int:
        start = 0
        end = len(flowers)
        while start < end:
            mid = start + (end - start) // 2

            if flowers[mid][whichOne] > target:
                end = mid
            else:
                start = mid + 1

        return start
