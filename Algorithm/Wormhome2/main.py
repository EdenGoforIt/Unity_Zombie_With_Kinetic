import sys
import heapq


class Star:

    def __init__(self, star_id):
        self.star_id = star_id
        self.edge_list = list()
        self.visited = False
        self.parent = None
        self.key = float('inf')

    def is_not_visited(self):
        if self.visited is True:
            return False
        return True

    def add_neighbor(self, to_star, time):
        edge = Edge(to_star, time)
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.key < other.key


class Edge:

    def __init__(self, to_star, time):
        self.to_star = to_star
        self.time = time


def wormhole(stars_list):

    visited_list = []
    current = stars_list[0]
    current.key = 0
    count = 0
    queue = list()
    queue.append(current)

    while count < len(stars_list):
        for st in stars_list:
            for edge in st.edge_list:
                total_weight = st.key + edge.time
                if total_weight < edge.to_star.key:
                    edge.to_star.key = total_weight
        count = count + 1

    possible = False
    for st in stars_list:
        for edge in st.edge_list:
            total_weight = st.key + edge.time
            if total_weight < edge.to_star.key:
                sys.stdout.write("{0}".format("possible\n"))
                return
    if possible is False:
        sys.stdout.write("{0}".format("not possible\n"))


def main():
    case_num = sys.stdin.readline()
    case_num = case_num.rstrip('\n')
    case_num = int(case_num)

    for c_num in range(0, case_num):
        stars_list = list()
        star_worm_number = sys.stdin.readline()
        star_worm_number = star_worm_number.split(" ")
        star_num = int(star_worm_number[0])
        worm_num = int(star_worm_number[1])
        for s_num in range(0, star_num):
            star = Star(s_num)
            stars_list.append(star)

        for w_num in range(0, worm_num):
            from_to_year = sys.stdin.readline()
            from_to_year = from_to_year.rstrip('\n')
            from_to_year = from_to_year.split(" ")
            from_star = int(from_to_year[0])
            to_star = int(from_to_year[1])
            year = int(from_to_year[2])
            stars_list[from_star].add_neighbor(stars_list[to_star], year)

        wormhole(stars_list)



if __name__ == "__main__":
    main()