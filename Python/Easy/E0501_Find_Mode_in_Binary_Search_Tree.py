import queue


# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def findMode(self, root: TreeNode) -> list[int]:
        dict = {}
        max = -1

        q = queue.Queue()
        q.put(root)
        while not q.empty():
            curr = q.get()
            if curr.val in dict:
                dict[curr.val] += 1
            else:
                dict[curr.val] = 1
            
            if max < dict[curr.val]:
                max = dict[curr.val]

            if curr.left != None:
                q.put(curr.left)
            
            if curr.right != None:
                q.put(curr.right)

        solution = []
        for item in dict.keys():
            if dict[item] == max:
                solution.append(item)

        return solution
