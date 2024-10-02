class Solution:
    def isMonotonic(self, nums: list[int]) -> bool:
        n = len(nums)
        if n <= 1:
            return True

        if nums[-1] - nums[0] > 0:
            for i in range(1, n):
                if nums[i - 1] > nums[i]:
                    return False
        else:
            for i in range(1, n):
                if nums[i - 1] < nums[i]:
                    return False
        return True
