import csv

actions = []
with open('input for zeliya.txt', newline='') as f:
    reader = csv.reader(f, delimiter=' ')
    for row in reader:
        actions.append(row)

ingredients = []
for action in actions:
    ingredients.append(action[1:])

spell = ""
cast = []
answer = []
for i in range(len(actions)):
    for j in range(len(ingredients[i])):
        if ingredients[i][j].isdigit():
            castIndex = int(ingredients[i][j])
            answer.pop(castIndex - 1)
            ingredients[i][j] = cast[castIndex - 1]

    if actions[i][0] == "MIX":
        spell += "MX" + "".join(ingredients[i]) + "XM"
    elif actions[i][0] == "WATER":
        spell += "WT" + "".join(ingredients[i]) + "TW"
    elif actions[i][0] == "DUST":
        spell += "DT" + "".join(ingredients[i]) + "TD"
    elif actions[i][0] == "FIRE":
        spell += "FR" + "".join(ingredients[i]) + "RF"

    cast.append(spell)
    answer.append(spell)
    spell = ""

for a in answer:
    print(a, end='')

input()