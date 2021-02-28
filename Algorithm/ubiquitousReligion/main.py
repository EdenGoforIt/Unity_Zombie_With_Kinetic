import sys
import heapq




class Edge:

    def __init__(self, from_person, to_person):
        self.from_person = from_person
        self.to_person = to_person
        self.spanningTree = False


class UnionFind:

    def __init__(self, x):
        self.parent = None
        self.rank = [0 for i in range(x)]
        self.disjoint_number = None
        self.make_set(x)

    def make_set(self, x):
        self.parent = list(range(x))
        self.disjoint_number = x

    def find_set(self, x):
        if self.parent[x]!=x:
            self.parent[x] = self.find_set(self.parent[x])
        return self.parent[x]

    def merge_set(self, x, y):
        root_x = self.find_set(x)
        root_y = self.find_set(y)


        ## if the root is the same, which means that they are in the same group, no merge occurs
        if root_x == root_y:
            return

        #anway if there is a join occurs, the number of religions might be one smaller.
        self.disjoint_number -= 1
        #alwasys put a group from lower rank to higher rank
        if self.rank[root_x] < self.rank[root_y]:
            self.parent[root_x] = root_y ## now y became the parent of parent[x]
        else:
            self.parent[root_y] = root_x
            if self.rank[root_x] == self.rank[root_y]:
                self.rank[root_x] += 1




def MST_Kruskal(answer_list, edge_list, ver_num, case_num):
    union_find = UnionFind(ver_num)
    mst_tree= list()
    for edge in edge_list:
        if not edge.spanningTree:
            if union_find.find_set(edge.from_person) != union_find.find_set(edge.to_person):
                mst_tree.append(edge)
                if len(mst_tree) == ver_num -1:
                    edge.spanningTree = True
                union_find.merge_set(edge.from_person, edge.to_person)
        else:
            return

    dis = union_find.disjoint_number
    answer = 'Case %i: %i' % (case_num+1, dis)
    answer_list.append(answer)



def main():

    line = sys.stdin.readline().strip()
    case_num = 0
    answer_list = list()
    while line!="0 0":
        edge_list = list()
        ver_num, edge_num = map(int, line.split())

        for e_num in range(0, edge_num):
            start_person, to_person = map(int, sys.stdin.readline().split())
            edge = Edge(start_person -1, to_person-1)
            edge_list.append(edge)

        MST_Kruskal(answer_list, edge_list, ver_num, case_num)
        case_num += 1
        line = sys.stdin.readline().strip()

    for answer in answer_list:
        print(answer)


if __name__ == "__main__":
    main()

