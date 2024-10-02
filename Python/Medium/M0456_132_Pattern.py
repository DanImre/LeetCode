class Solution:
    def find132pattern(self, nums: list[int]) -> bool:
        n = len(nums)

        min_from_left = [nums[0]]
        for i in range(1, n):
            min_from_left.append(min(min_from_left[-1], nums[i]))

        stack = []

        for i in range(n - 1, -1, -1):
            if nums[i] <= min_from_left[i]:
                continue
            while stack and stack[-1] <= min_from_left[i]:
                stack.pop()
            if stack and stack[-1] < nums[i]:
                return True
            stack.append(nums[i])

        return False
