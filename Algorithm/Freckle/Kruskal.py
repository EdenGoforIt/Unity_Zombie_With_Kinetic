import sys


def main():
    global case_num, freckle_num, adj_list

    case_num = sys.stdin.readline()
    case_num = int(case_num)
    skip_blank = sys.stdin.readline()
    for num in range(0, case_num):
        freckle_num = int(sys.stdin.readline())
        for one_freckle in range(0, freckle_num):
            one_freckle = one_freckle.strip().split(" ")





if __name__ == "__main__":
    main()

