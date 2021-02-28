import math
import sys


class Freckle(object):

    def __init__(self, x_position, y_position, freckle_id):
        self.freckle_id = freckle_id
        self.x_position = x_position
        self.y_position = y_position
        self.key = float('inf')
        self.parent = None
        self.visited = False
        self.edge_list = list()

    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def add_neighbor(self, to_freckle, weight):
        edge = Edge(to_freckle, weight)
        self.edge_list.append(edge)


class Edge(object):

    def __init__(self, to_freckle, weight):
        self.to_freckle = to_freckle
        self.weight = weight


def find_the_smallest_weight(queue):
    min = queue[0]
    for a in queue:
        if a.key < min.key:
            min = a

    return min


def prim(freckle_list):
    queue = freckle_list
    visited_list = list()
    start_ver = queue[0]
    start_ver.key = 0

    while queue:
        current = find_the_smallest_weight(queue)
        for edge in current.edge_list:
            if edge.to_freckle.is_not_visited():
                if edge.weight < edge.to_freckle.key:
                    edge.to_freckle.key = edge.weight
                    edge.to_freckle.parent = current
                    current.visited = True

        visited_list.append(current)

        count = 0
        for ver in queue:
            if ver.freckle_id == current.freckle_id:
                queue.pop(count)
            count = count + 1

    total_weight = get_the_total_weight(visited_list)
    sys.stdout.write("\n{0}".format(total_weight))


def get_the_total_weight(visited_list):

    total_weight = 0
    for one in visited_list:
        total_weight = total_weight + one.key

    return round(total_weight, 2)


def assign_weight(freckle_list):

    for one in range(0, len(freckle_list)-1, 1):
        for two in range(one+1, len(freckle_list)):
            edge = Edge(freckle_list[two], euclidean_distance(freckle_list[one], freckle_list[two]))
            freckle_list[one].edge_list.append(edge)


def euclidean_distance(freckle_a, freckle_b):
    distance = math.sqrt((freckle_a.x_position-freckle_b.x_position)**2 +(freckle_a.y_position-freckle_b.y_position)**2)
    return distance


def main():

    freckle_list = list()
    case_num = sys.stdin.readline()
    case_num = int(case_num)

    for num in range(0, case_num):
        skip_blank = sys.stdin.readline()
        freckle_num = int(sys.stdin.readline())
        for frec_id in range(0, freckle_num):
            positions = sys.stdin.readline()
            positions = positions.rstrip('\n')
            positions = positions.split(" ")
            x_position = float(positions[0])
            y_position = float(positions[1])
            freckle = Freckle(x_position, y_position, frec_id)
            freckle_list.append(freckle)
        assign_weight(freckle_list)
        prim(freckle_list)




if __name__ == "__main__":
    main()

