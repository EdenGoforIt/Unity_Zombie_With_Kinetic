class Vertex(object):
    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.adj_list = list()
        self.status = self.UNDISCOVERED()
        self.parent = None

    def set_undiscovered(self):
        self.status = self.UNDISCOVERED()

    def set_discovered(self):
        self.status = self.DISCOVERED()

    def set_processed(self):
        self.status = self.PROCESSED()

    def is_undiscovered(self):
        if self.status == 0:
            return True
        return False

    def set_parent(self, parent):
        self.parent = parent

    def get_parent(self):
        return self.parent

    def add_neighbor(self, v):
        self.adj_list.append(v)
        self.sort_adj_list()

    def sort_adj_list(self):
        return sorted(self.adj_list, key = lambda x: x.vertex_id)

    def UNDISCOVERED(self):
        return 0
    def DISCOVERED(self):
        return 1
    def PROCESSED(self):
        return 2
    def NONE(self):
        return -1








