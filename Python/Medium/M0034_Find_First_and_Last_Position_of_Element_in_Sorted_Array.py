class Solution:
    def searchRange(self, nums: list[int], target: int) -> list[int]:
        n = len(nums)
        if n == 0:
            return [-1, -1]

        start = 0
        end = n - 1

        while start < end:
            mid = start + (end - start) // 2

            if nums[mid] < target:
                start = mid + 1
            else:
                end = mid

        if nums[start] != target:
            return [-1, -1]

        solution = []
        solution.append(start)

        end = n - 1

        while start < end:
            mid = start + (end - start + 1) // 2

            if nums[mid] > target:
                end = mid - 1
            else:
                start = mid

        solution.append(start)

        return solution
