import sys
import heapq

class City:

    def __init__(self, city_id):
        self.city_id = city_id
        self.key = float('inf')
        self.parent = None
        self.edge_list = list()
        self.visited = False
        #self.city_name = None

    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def add_neighbor(self, edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.key < other.key

class Edge:

    def __init__(self, to_vertex, cost):
        self.to_vertex = to_vertex
        self.cost = cost

    def __lt__(self, other):
        return 0

def MST(vertices_list):

    queue = []
    heapq.heappush(queue, vertices_list[0])
    vertices_list[0].key = 0
    total_weight = 0
    visited_list = list()
    while queue:
        current = heapq.heappop(queue)
        if current.visited:
            continue
        for edge in current.edge_list:
            if not edge.to_vertex.visited:
                if edge.cost < edge.to_vertex.key:
                    edge.to_vertex.key = edge.cost
                    heapq.heappush(queue, edge.to_vertex)
                    #edge.to_vertex.parent = current

        current.visited = True
        visited_list.append(current)
        total_weight += current.key

    totall = 0
    for x in visited_list:
        totall += x.key
    return totall
    #sys.stdout.write("{0}".format(totall))

class TestCase:
    def __init__(self, vertices):
        self.vertices = vertices

testcases = []

def main():

    case_num = int(sys.stdin.readline())
    #skip_line = sys.stdin.readline()
    for n_case in range(0, case_num):
        vertices_list = list()
        sys.stdin.readline()

        number_of_city = int(sys.stdin.readline())
        #interate and make for the time of number of cities
        for n_city in range(0, number_of_city):
            city = City(n_city)
            vertices_list.append(city)

        for n_city in range(0, number_of_city):
            c_name = sys.stdin.readline()
            #vertices_list[n_city].city_name = c_name
            num_neighbor = int(sys.stdin.readline())
            for n_neigh in range(0, num_neighbor):
                to_city_cost = sys.stdin.readline()
                to_city_cost = to_city_cost.split(" ")
                to_city = int(to_city_cost[0])
                cost = int(to_city_cost[1])
                edge = Edge(vertices_list[to_city-1], cost)
                vertices_list[n_city].edge_list.append(edge)

        # MST(vertices_list)
        testcase = TestCase(vertices_list)
        testcases.append(testcase)

    count = 0
    for testcase in testcases:
        print(MST(testcase.vertices))
        # if count < case_num - 1:
        #     print()
        # count = count + 1



if __name__ == "__main__":
    main()