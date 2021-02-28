import sys

class Vertex(object):

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.key = float('inf')
        self.parent = None
        self.visited = False
        self.edge_list = list()

    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def is_visited(self):
        if self.visited is True:
            return True
        return False

    def add_neighbor(self, to_vertex, weight):
        edge = Edge(to_vertex, weight)
        self.edge_list.append(edge)


class Edge(object):

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def find_the_smallest_number(queue):
    min = queue[0]
    for a in queue:
        if a.key < min.key:
            min = a

    return min


def daikstra(vertices_list, source_vertex, destination_vertex):
    queue = vertices_list
    visited_list = list()
    start_ver = queue[source_vertex.vertex_id-1]
    start_ver.key = 0

    """ start by setting the starting vertex key as 0 and other keys to infinite"""
    while queue:
        """ find the node having the shortest key    """
        current = find_the_smallest_number(queue)
        current_weight = current.key
        for edge in current.edge_list:
            """ find the all neighbors and compare the key and set the value 
             and the parent as well """

            if edge.to_vertex.is_not_visited():
                total_weight = current_weight + edge.weight
                if total_weight < edge.to_vertex.key:
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current
                    current.visited = True

        visited_list.append(current)
        if current.vertex_id == destination_vertex.vertex_id:
            break
        """" remove the instance safely from the queue"""
        count = 0
        for ver in queue:
            if ver.vertex_id == current.vertex_id:
                queue.pop(count)
            count = count + 1

    total_cost = 0
    for x in visited_list:
        if destination_vertex.vertex_id == x.vertex_id:
            total_cost = x.key
    if total_cost == 0 or total_cost == float('inf'):
        sys.stdout.write("\n{0}".format("NO"))
    else:
        sys.stdout.write("\n{0}".format(total_cost))

def main():

    case_line = sys.stdin.readline()
    case_line = case_line.rstrip('\n')
    case_number = int(case_line)

    for case in range(0, case_number):
        vertices_list = list()
        first_line = sys.stdin.readline()
        first_line = first_line.rstrip('\n')
        first_line = first_line.split(" ")
        vertex_number = int(first_line[0])
        edge_number = int(first_line[1])
        for x in range(1, vertex_number+1, 1):
            vertex = Vertex(x)
            vertices_list.append(vertex)

        for x in range(0, edge_number):
            second_line = sys.stdin.readline()
            second_line = second_line.rstrip('\n')
            second_line = second_line.split(" ")
            from_vertex = int(second_line[0])-1
            to_vertex = int(second_line[1])-1
            weight = int(second_line[2])
            vertices_list[from_vertex].add_neighbor(vertices_list[to_vertex], weight)

        third_line = sys.stdin.readline()
        third_line = third_line.rstrip('\n')
        third_line = third_line.split(' ')
        source_vertex = int(third_line[0])-1
        destination_vertex = int(third_line[1])-1
        daikstra(vertices_list, vertices_list[source_vertex], vertices_list[destination_vertex])



if __name__ == "__main__":
    main()