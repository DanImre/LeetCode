class Solution:
    def maxDotProduct(self, nums1: list[int], nums2: list[int]) -> int:
        max1 = nums1[0]
        min1 = nums1[0]
        max2 = nums2[0]
        min2 = nums2[0]
        for i in nums1:
            max1 = max(max1, i)
            min1 = min(min1, i)
        for i in nums2:
            max2 = max(max2, i)
            min2 = min(min2, i)

        if max1 < 0 and min2 > 0:
            return max1 * min2
        if max2 < 0 and min1 > 0:
            return max2 * min1

        self.nums1 = nums1
        self.nums2 = nums2

        n1 = len(nums1)
        n2 = len(nums2)
        self.dp = []
        for i in range(n1):
            self.dp.append([])
            for j in range(n2):
                self.dp[i].append(None)

        return self.RecursiveSolution(0, 0, n1, n2)

    def RecursiveSolution(self, index1, index2, n1, n2):
        if index1 == n1 or index2 == n2:
            return 0

        if self.dp[index1][index2] != None:
            return self.dp[index1][index2]

        use = self.nums1[index1] * self.nums2[index2] + self.RecursiveSolution(index1 + 1, index2 + 1, n1, n2)

        solution = max(use, self.RecursiveSolution(index1 + 1, index2, n1, n2), self.RecursiveSolution(index1, index2 + 1, n1, n2))
        
        self.dp[index1][index2] = solution
        return solution
