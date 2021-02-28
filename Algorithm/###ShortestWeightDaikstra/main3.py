import sys
import heapq
from builtins import list
from copy import copy, deepcopy


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id  = vertex_id
        self.parent = None
        self.visited = False
        self.edge_list = list()
        self.
