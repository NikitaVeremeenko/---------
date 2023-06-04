with open('input.txt') as f:
    kurs1 = []
    lucky1 = []
    kurs2 = []
    lucky2 = []
    money1 = []
    for i, line in enumerate(f):
        if i == 0:
            kurs1 = list(map(int, line.strip().split()[1:]))
        elif i == 1:
            lucky1 = list(map(int, line.strip().split()[1:]))
        elif i == 2:
            kurs2 = list(map(int, line.strip().split()[1:]))
        elif i == 3:
            lucky2 = list(map(int, line.strip().split()[1:]))
        elif i == 4:
            money1 = list(map(int, line.strip().split()))

if kurs2[0] != 0:
    money2 = [0] * (len(kurs2) + 1)
else:
    money2 = [0]

lucky1.sort()
lucky2.sort()
lucky1.reverse()

for i in range(len(money1)):
    for t in range(len(lucky1)):
        if lucky1[t] <= money1[i]:
            money1[i] -= 1

for i in range(len(money1) - 1):
    money1[i + 1] += money1[i] * kurs1[i]

money2[-1] = money1[-1]

for i in range(len(money2) - 2, -1, -1):
    money2[i] = money2[i + 1] // kurs2[i]
    money2[i + 1] = money2[i + 1] % kurs2[i]

for i in range(len(money2)):
    for t in range(len(lucky2)):
        if lucky2[t] <= money2[i]:
            money2[i] += 1

print(*money2)