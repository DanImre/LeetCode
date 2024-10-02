import math


def anagram(s1: str,s2: str):
    s1 = s1.replace(' ','')
    s2 = s2.replace(' ','')

    if len(s1) != len(s2):
        return False

    dict = {}
    for item in s1:
        if item not in dict.keys():
            dict[item.lower()] = 0
        dict[item] += 1
    for item in s2:
        if item.lower() not in dict.keys() or dict[item.lower()] == 0:
            return False
        
        dict[item.lower()] -= 1

    return True


def shopping(prices):
    minI = -1
    minSum = -1
    for i in range(0, len(prices)):
        sum = prices[i]["tojás"] + prices[i]["kenyér"] + prices[i]["tej"]
        if minSum == -1:
            minSum = sum
            minI = i
        elif minSum > sum:
            minSum = sum
            minI = i
    
    return (minI, minSum)

def email_checker(email :str) -> bool:
    if email.count("@") != 1:
        return False
    
    email = email.strip()

    temp = email.split("@")

    for item in temp[0]:
        if not item.isalpha():
            return False
    
    if email.count(".") < 1 or email.count(".") > 2:
        return False
    
    temp = email[1].split(".")
    for item in temp[0]:
        if not item.isalpha():
            return False
        
    for i in range(1,len(temp)):
        for item in temp[i]:
            if not item.isalpha():
                return False
    
    return True


# print(anagram("dán ropifestő", "Petőfi Sándor"))

# store0 = {"tej": 200, "kenyér": 700, "tojás": 800, "sör": 500}
# store1 = {"tej": 100, "tojás": 800, "kenyér": 750}
# prices = [store0, store1]
# print(shopping(prices))

print(email_checker("info@email.com"))