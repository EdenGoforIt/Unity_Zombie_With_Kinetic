class Room:
    def __init__(self, room_id):
        self.room_id = room_id
        self.adj_list = list()
        self.status = 0
        self.parent = None

    def get_parent(self):
        return self.parent

    def undiscovered(self):
        self.status = 0

    def discovered(self):
        self.status = 1

    def is_discovered(self):
        if self.status == 1:
            return True
        return False

    def add_neighbor(self, room):
        self.adj_list.append(room)
        self.sort_adj_sort()

    def sort_adj_sort(self):
        self.adj_list = sorted(self.adj_list, key=lambda x: x.room_id)