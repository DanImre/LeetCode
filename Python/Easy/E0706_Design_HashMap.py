class MyHashMapNode:
    def __init__(self, value = -1, key = -1):
        self.value = value
        self.key = key
        self.next = None


class MyHashMap:
    def __init__(self):
        self.array = [None for i in range(0, 1000)]

    def put(self, key: int, value: int) -> None:
        actualIndex = key % 1000
        if self.array[actualIndex] == None:
            self.array[actualIndex] = MyHashMapNode()

        curr = self.array[actualIndex]
        while curr.next != None:
            if curr.key == key:
                curr.value = value
                return
            else:
                curr = curr.next

        if curr.key == key:
            curr.value = value
        else:
            curr.next = MyHashMapNode(value=value, key=key)

    def get(self, key: int) -> int:
        actualIndex = key % 1000
        if self.array[actualIndex] == None:
            self.array[actualIndex] = MyHashMapNode()

        curr = self.array[actualIndex]
        while curr != None:
            if curr.key == key:
                return curr.value
            else:
                curr = curr.next

        return -1

    def remove(self, key: int) -> None:
        actualIndex = key % 1000
        if self.array[actualIndex] == None:
            self.array[actualIndex] = MyHashMapNode()

        curr = self.array[actualIndex]
        while curr.next != None:
            if curr.next.key == key:
                curr.next = curr.next.next
                return
            else:
                curr = curr.next


# Your MyHashMap object will be instantiated and called as such:
# obj = MyHashMap()
# obj.put(key,value)
# param_2 = obj.get(key)
# obj.remove(key)
