# write your code here
game_over = False
not_done = 9
grid = [[" ", " ", " "], [" ", " ", " "], [" ", " ", " "]]

print("---------")
print(f'| {grid[0][0]} {grid[0][1]} {grid[0][2]} |')
print(f'| {grid[1][0]} {grid[1][1]} {grid[1][2]} |')
print(f'| {grid[2][0]} {grid[2][1]} {grid[2][2]} |')
print("---------")

while not game_over:
    not_valid = True
    while not_valid:
        coord = input("Enter the coordinates: ").split()
        if coord[0].isdigit() and coord[1].isdigit:
            coordinate_row = int(coord[0]) - 1
            coordinate_col = int(coord[1]) - 1
            if coordinate_row > 2 or coordinate_col > 2:
                print("Coordinates should be from 1 to 3!")
            elif grid[coordinate_row][coordinate_col] != " ":
                print("This cell is occupied! Choose another one!")
            else:
                not_valid = False
                not_done -= 1
                if not_done % 2 == 0:
                    grid[coordinate_row][coordinate_col] = "X"
                else:
                    grid[coordinate_row][coordinate_col] = "O"

                # # checking winning
                row1 = [grid[0][0], grid[0][1], grid[0][2]]
                row2 = [grid[1][0], grid[1][1], grid[1][2]]
                row3 = [grid[2][0], grid[2][1], grid[2][2]]
                column1 = [grid[0][0], grid[1][0], grid[2][0]]
                column2 = [grid[0][1], grid[1][1], grid[2][1]]
                column3 = [grid[0][2], grid[1][2], grid[2][2]]
                diagonal1 = [grid[0][0], grid[1][1], grid[2][2]]
                diagonal2 = [grid[0][2], grid[1][1], grid[2][0]]

                game = [row1, row2, row3, column1, column2, column3, diagonal1, diagonal2]

                winx = False
                wino = False
                for win_type in game:
                    if win_type[0] == win_type[1] == win_type[2]:
                        if win_type[0] == "X":
                            winx = True
                        elif win_type[0] == "O":
                            wino = True
                        else:
                            continue

                print("---------")
                print(f'| {grid[0][0]} {grid[0][1]} {grid[0][2]} |')
                print(f'| {grid[1][0]} {grid[1][1]} {grid[1][2]} |')
                print(f'| {grid[2][0]} {grid[2][1]} {grid[2][2]} |')
                print("---------")
                if winx:
                    game_over = True
                    print("X wins")
                elif wino:
                    game_over = True
                    print("O wins")
                elif not_done == 0:
                    print("Draw")
                    game_over = True
        else:
            print("You should enter numbers!")





# # checking winning
# row1 = [grid[0][0], [grid[0][1], [grid[0][2]]
# row2 = [grid[1][0], [grid[1][1], [grid[1][2]]
# row3 = [grid[2][0], [grid[2][1], [grid[2][2]]
# column1 = [grid[0][0], [grid[1][0], [grid[2][0]]
# column2 = [grid[0][1], [grid[1][1], [grid[2][1]]
# column3 = [grid[0][2], [grid[1][2], [grid[2][2]]
# diagonal1 = [grid[0][0], [grid[1][1], [grid[2][2]]
# diagonal2 = [grid[0][2], [grid[1][1], [grid[2][0]]
#
# game = [row1, row2, row3, column1, column2, column3, diagonal1, diagonal2]
#
# winx = False
# wino = False
# for win_type in game:
#     if win_type[0] == win_type[1] == win_type[2]:
#         if win_type[0] == "X":
#             winx = True
#         elif win_type[0] == "O":
#             wino = True
#
# if abs(countx - counto) > 1:
#     print("Impossible")
# elif winx == True:
#     if wino == True:
#         print("Impossible")
#     else:
#         print("X wins")
# elif wino == True:
#     if winx == True:
#         print("Impossible")
#     else:
#         print("O wins")
# elif notdone > 0:
#     print("Game not finished")
# else:
#     print("Draw")
