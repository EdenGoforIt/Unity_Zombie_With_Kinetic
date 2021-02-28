import copy
import heapq
import sys
import threading
import time
from timeit import default_timer as timer, timeit
from datetime import timedelta, datetime
import numpy as np


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.key = float('inf')
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


def find_the_smallest_vertex(queue):#linear
    min = queue[0]
    index = 0
    for x in range(0, len(queue)):
        if min.key > queue[x].key:
            min = queue[x]
            index = x
    current = queue.pop(index)
    return current


def sort_and_return_smallest(queue): #sort  best: O(n) worst:log(n logn)
    queue.sort(key=lambda x: x.key)

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
                total_weight = current_ver.key + edge.weight
                if total_weight < edge.to_vertex.key:
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current_ver
                    queue.append(edge.to_vertex)
        current_ver.visited = True
        visited_list.append(current_ver)

    sys.stdout.write("Case {0}: {1}\n".format(c_num, vertices_list[end_vertex.vertex_id].key))


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
    sys.stdout.write("Case {0}: {1}\n".format(c_num, vertices_list[end_vertex.vertex_id].key))


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

                total_weight = current_ver.key + edge.weight
                if total_weight < edge.to_vertex.key:
                    queue.append(edge.to_vertex)
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current_ver

    sys.stdout.write("CASE {0}: {1}\n".format(c_num, vertices_list[end_vertex.vertex_id].key))


def floyd(grid, c_num, vertex_num, start_ver, end_ver):

    #first make self vertex weight 0

    #other make infinite
    for i in range(vertex_num):
        for j in range(vertex_num):
            if grid[i][j] == 0:
                grid[i][j] = float('inf')

    for k in range(vertex_num):
        for i in range(vertex_num):
            for j in range(vertex_num):
                if grid[i][k] + grid[k][j] < grid[i][j]:
                    grid[i][j] = grid[i][k] + grid[k][j]

    print("CASE {0}: {1}".format(c_num, int(grid[start_ver][end_ver])))


def main():
    start_time = time.time()
    # start_time = datetime.now()
    # # # sort_start_time = time.time()
    # heap_start_time = time.time()

    case_list = list()
    n_case = load_num_case()
    for c_num in range(0, n_case):
        vertices_list = list()
        vertex_num, edge_num = map(int, sys.stdin.readline().split())
        start_ver, end_ver = map(int, sys.stdin.readline().split())
        grid = np.zeros((vertex_num, vertex_num))
        for e_num in range(edge_num):
            from_ver, to_ver, weight = map(int, sys.stdin.readline().split())
            grid[from_ver, to_ver] = weight
            grid[to_ver, from_ver] = weight

        floyd(grid, c_num, vertex_num, start_ver, end_ver)


        # linear_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)



        # sort_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)



       # heap_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)

    e = int(time.time() - start_time)
    # e = datetime.now() - start_time
    # # print(e)
    print('{:02d}:{:02d}:{:02d}'.format(e // 3600, (e % 3600 // 60), e % 60))
    # print("    Sort - %s seconds -" % (time.time() - sort_start_time))
    # print("    Heap - %s seconds -" % (time.time() - heap_start_time))

if __name__ == "__main__":

    main()


