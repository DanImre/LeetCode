class Solution:
    def majorityElement(self, nums: list[int]) -> list[int]:
        dic = {}
        for item in nums:
            if item in dic:
                dic[item] += 1
            else:
                dic[item] = 1

        solution = []
        limit = len(nums) // 3
        print(limit)
        for item in dic.keys():
            if dic[item] > limit:
                solution.append(item)

        return solution
