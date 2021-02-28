import copy
import heapq
import math
import sys
import threading
import time
from timeit import default_timer as timer, timeit
from datetime import timedelta, datetime


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.key = 1000000
        self.edge_list = list()
        self.visited = False

    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def __lt__(self, other):
        return self.key < other.key


class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def load_num_case():
    return int(sys.stdin.readline().strip())


def find_the_smallest_vertex(queue):
    min = queue[0]
    index = 0
    for x in range(0, len(queue)):
        if min.key > queue[x].key:
            min = queue[x]
            index = x

    return queue.pop(index)


def sort_and_return_smallest(queue):
    queue.sort(key=lambda x:x.key)
    #queue = sorted(queue, key=lambda x: x.key)
    ## not working
    current = queue.pop(0)
    return current


def sort_daikstra(c_num, start_vertex, end_vertex, vertices_list):
    queue = []
    visited_list = list()
    current_ver = start_vertex
    current_ver.key = 0
    queue.append(current_ver)

    while queue:
        current_ver = sort_and_return_smallest(queue)
        if current_ver.visited is True:
            continue
        for edge in current_ver.edge_list:
            if edge.to_vertex.is_not_visited():
                queue.append(edge.to_vertex)
                total_weight = current_ver.key + edge.weight
                if total_weight < edge.to_vertex.key:
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current_ver
        current_ver.visited = True
        visited_list.append(current_ver)

    for x in visited_list:
        if x.vertex_id == end_vertex.vertex_id:
            if x.key == int(1000000):
                sys.stdout.write("CASE {0}: {1}\n".format(c_num, "NO PASS"))
            else:
                sys.stdout.write("CASE {0}: {1}\n".format(c_num, x.key))



def heap_daikstra(c_num, start_vertex, end_vertex, vertices_list):
    queue = list()
    current_ver = start_vertex
    heapq.heappush(queue, current_ver)
    current_ver.key = 0

    while queue:
        current_ver = heapq.heappop(queue)
        # if current_ver.visited is True: continue
        for edge in current_ver.edge_list:
            if edge.to_vertex.is_not_visited():

                if current_ver.key + edge.weight < edge.to_vertex.key:
                    edge.to_vertex.key = current_ver.key + edge.weight
                    edge.to_vertex.parent = current_ver
                    heapq.heappush(queue, edge.to_vertex)
        current_ver.visited = True

    if vertices_list[end_vertex.vertex_id].key == 1000000:
        sys.stdout.write("CASE {0}: {1}".format(c_num, "no path"))
    else:
        sys.stdout.write("Case {0}: {1}".format(c_num, vertices_list[end_vertex.vertex_id].key))



def linear_daikstra(c_num, start_vertex, end_vertex, vertices_list):
    queue = []

    current_ver = start_vertex
    current_ver.key = 0
    queue.append(start_vertex)

    while queue:
        current_ver = find_the_smallest_vertex(queue)
        current_ver.visited = True
        for edge in current_ver.edge_list:
            if edge.to_vertex.is_not_visited():
                queue.append(edge.to_vertex)
                total_weight = current_ver.key + edge.weight
                if total_weight < edge.to_vertex.key:
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current_ver

    sys.stdout.write("CASE {0}: {1}".format(c_num, vertices_list[end_vertex.vertex_id].key)).rstrip()



def main():
    case_list = list()
    n_case = load_num_case()

    for c_num in range(0, n_case):
        vertices_list = list()
        vertex_num, edge_num = map(int, sys.stdin.readline().split())
        for v_num in range(0, vertex_num):
            vertex = Vertex(v_num)
            vertices_list.append(vertex)
        start_vertex, end_vertex = map(int, sys.stdin.readline().split())

        for e_num in range(0, edge_num):
            from_vertex, to_vertex, weight = map(int, sys.stdin.readline().split())
            edge = Edge(vertices_list[to_vertex], weight)
            edge2= Edge(vertices_list[from_vertex], weight)
            vertices_list[from_vertex].edge_list.append(edge)
            vertices_list[to_vertex].edge_list.append(edge2)
        # linear_list = copy.deepcopy(vertices_list)
        # sort_list = copy.deepcopy(vertices_list)
        # heap_list = copy.deepcopy(vertices_list)


        # linear_start_time = datetime.now()
        # linear_daikstra(c_num, linear_list[start_vertex], linear_list[end_vertex], linear_list)


        # print("    Linear - %s seconds -" % (datetime.now()  - linear_start_time))

        # sort_start_time = time.time()
        # sort_daikstra(c_num, sort_list[start_vertex], sort_list[end_vertex], sort_list)
        # print("    Sort - %s seconds -" % (time.time() - sort_start_time))
        #
        # heap_start_time = time.time()
        # heap_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)
        count = 0
        if c_num < n_case-1:
            print()
            count+=1
        # print("    Heap - %s seconds -" % (time.time() - heap_start_time))
        # #
        #




if __name__ == "__main__":

    main()


