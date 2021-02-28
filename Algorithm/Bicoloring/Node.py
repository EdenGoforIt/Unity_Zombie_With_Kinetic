class Node:

    def __init__(self, node_id):
        self.node_id = node_id
        self.adj_list = list()
        self.color = None
        self.parent = None

    def is_not_colored(self):
        if self.color == 1 or self.color == 0:
            return False
        return True

    def color_differently(self, incoming_color):
        if self.is_not_colored():
            if incoming_color == 1:
                self.color = 0
            if incoming_color == 0:
                self.color = 1
    def is_colored(self):
        if self.color == 1 or self.color ==0:
            return True
        return False

    def set_color_to_black(self):
        self.color = 1

    def set_color_to_white(self):
        self.color = 0

    def get_color(self):
        return self.color

    def add_neighbor(self, node):
        self.adj_list.append(node)
        self.sort_adj_list()

    def sort_adj_list(self):
        self.adj_list = sorted(self.adj_list, key=lambda x: x.node_id)

