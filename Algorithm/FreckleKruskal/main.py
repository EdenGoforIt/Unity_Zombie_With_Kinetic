import math
import sys

class Freckle:

    def __init__(self, freckle_id, x_position, y_position):
        self.freckle_id = freckle_id
        self.x_position = x_position
        self.y_position = y_position


class Edge(object):

    def __init__(self, edge_id,  start_freckle, to_freckle, weight):
        self.edge_id = edge_id
        self.start_freckle = start_freckle
        self.to_freckle = to_freckle
        self.weight = weight
        self.spanning_tree = False





def assign_weight(freckle_list, edge_list):

    # for one in range(0, len(freckle_list)-1, 1):
    #     for two in range(one+1, len(freckle_list)):
    #         weight = euclidean_distance(freckle_list[one], freckle_list[two])
    #         edge = Edge(freckle_list[two], euclidean_distance(freckle_list[one], freckle_list[two]))
    #         freckle_list[one].edge_list.append(edge)
    edge_id = 0
    for one in range(0, len(freckle_list)-1):
        for two in range(1, len(freckle_list), 1):
            weight = euclidean_distance(freckle_list[one], freckle_list[two])
            if weight == 0:
                continue
            else:
                edge = Edge(edge_id, freckle_list[one], freckle_list[two], weight)
                edge_list.append(edge)
            edge_id +=1


def euclidean_distance(edge_one, edge_two):
    distance = math.sqrt((edge_one.x_position-edge_two.x_position)**2 +(edge_one.y_position-edge_two.y_position)**2)
    return distance


def kruskal(answer_list, freckle_list, freckle_num):
    edge_list = list()
    assign_weight(freckle_list, edge_list)
    union_find = UnionFind(len(edge_list))
    mst_tree = list()
    edge_list.sort(key=lambda one_edge: one_edge.weight)
    for edge in edge_list:
        if not edge.spanning_tree:
            if union_find.find_set(edge.start_freckle.freckle_id) != union_find.find_set(edge.to_freckle.freckle_id):
                mst_tree.append(edge)
                if len(mst_tree) == freckle_num - 1:
                    edge.spanning_tree = True
                union_find.merge_set(edge.start_freckle.freckle_id, edge.to_freckle.freckle_id)
            edge_list.sort(key=lambda one_edge: one_edge.weight)
        else:
            return
    total = 0
    for x in mst_tree:
        total += x.weight

    answer_list.append(round(total, 2))



class UnionFind:

    def __init__(self, freckle_num):
        self.parent = None
        self.create_set(freckle_num)

    def create_set(self, freckle_num):
        self.parent = list(range(freckle_num))
    ## parent[0] = 0, parent[1]=1 ...

    def find_set(self, freckle_num):
        if self.parent[freckle_num] != freckle_num:
            self.parent[freckle_num] = self.find_set(self.parent[freckle_num])
        return self.parent[freckle_num]

    ##who is the parent of freckle number 3? , then it should return which is the root

    def merge_set(self, one_freckle, two_freckle):
        self.parent[self.find_set(one_freckle)] = self.find_set(two_freckle)

    ##merge it. For example... parent[0] = 0, 1

def main():
    answer_list = list()

    freckle_list = list()
    case_num = sys.stdin.readline()
    case_num = int(case_num)

    for num in range(0, case_num):
        freckle_list = list()
        skip_blank = sys.stdin.readline()
        freckle_num = int(sys.stdin.readline())
        for one_freckle in range(0, freckle_num):
            positions = sys.stdin.readline()
            positions = positions.rstrip('\n')
            positions = positions.split(" ")
            x_position = float(positions[0])
            y_position = float(positions[1])
            freckle = Freckle(one_freckle, x_position, y_position)
            freckle_list.append(freckle)
        # if num == 0:
        #     sys.stdout.write("\n")
        kruskal(answer_list, freckle_list, freckle_num)
    count = 0
    for answer in answer_list:
        #sys.stdout.write(str(answer))
        print(answer)
        if count < len(answer_list)-1:
            print()
        count +=1


if __name__ == "__main__":
    main()