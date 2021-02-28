from Node import Node
import sys


class Bicoloring:

    @staticmethod
    def check_can_be_bicolored(incoming_list):
        queue = list()

        #check if colored, if not set it black
        # cihldren nodes check if colored, if not, different color
        # add queue, check if colored,

        for ver in range(0, len(incoming_list)):
            first_node = incoming_list[ver]
            if first_node.is_not_colored():
                first_node.set_color_to_black()
                queue.append(first_node)
            while len(queue) > 0:
                current = queue.pop(0)
                for x in incoming_list[current.node_id].adj_list:
                    if x.is_not_colored():
                        queue.append(x)
                        x.color_differently(current.color)
                    if x.is_colored():
                        if current.color == x.color:
                            print()
                            return "NOT BICOLORABLE."

        return "BICOLORABLE."
                    ## set the current color to black
                    ## set adjlist of vertices to different color
                    ## if neibors have the same == NONbiolocrable
                    ##


if __name__ == '__main__':

    ver_num = sys.stdin.readline()
    ver_num = ver_num.rstrip('\n')
    ver_num = int(ver_num)
    while ver_num != 0:
        node_list = list()
        for x in range(0, ver_num):
            node = Node(x)
            node_list.append(node)
        edge_num = sys.stdin.readline()
        edge_num = edge_num.rstrip('\n')
        edge_num = int(edge_num)
        for x in range(0, edge_num):
            read_vertices = sys.stdin.readline()
            read_vertices = read_vertices.rstrip('\n')
            read_vertices = read_vertices.split(' ')
            a = int(read_vertices[0])
            b = int(read_vertices[1])
            node_list[a].add_neighbor(node_list[b])
            node_list[b].add_neighbor(node_list[a])

        bicoloring = Bicoloring()
        print(bicoloring.check_can_be_bicolored(node_list))
        ver_num = sys.stdin.readline()
        ver_num = ver_num.rstrip('\n')
        ver_num = int(ver_num)


