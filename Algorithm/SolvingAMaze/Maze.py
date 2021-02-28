import sys
from Room import Room

class Maze:

    @staticmethod
    def find_the_shortest_path(room_list, start, end):
        queue = list()
        queue.append(room_list[start])

        while len(queue) > 0:
            current = queue.pop(0)
            current.status = 1
            for neighbor in room_list[current.room_id].adj_list:
                if neighbor.status == 0:
                    queue.append(neighbor)
                    neighbor.status = 1
                    neighbor.parent = current

        que = list()
        result = list()
        que.append(room_list[end])
        result.insert(0, room_list[end])
        while len(que) > 0:
            ver = que.pop(0)
            if room_list[ver.room_id].parent:
                parent = room_list[ver.room_id].parent
                que.append(parent)
                result.insert(0, parent)

        for xx in result:
            print(xx.room_id, end=" ")






if __name__ == '__main__':

    room_list = list()
    room_number = int(sys.stdin.readline())
    start_room = 0
    end_room = room_number -1

    for r in range(0, room_number):
        room = Room(r)
        room_list.append(room)

    edge_numbers = sys.stdin.readline()
    edge_numbers =edge_numbers.rstrip('\n')
    while edge_numbers!='':
        edge_numbers = edge_numbers.split(' ')
        a = int(edge_numbers[0])
        b = int(edge_numbers[1])
        room_list[a].add_neighbor(room_list[b])
        room_list[b].add_neighbor(room_list[a])
        edge_numbers = sys.stdin.readline()
        edge_numbers = edge_numbers.rstrip('\n')

    maze = Maze()
    maze.find_the_shortest_path(room_list, start_room, end_room)
