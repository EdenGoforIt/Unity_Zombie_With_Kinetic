import sys

class Point:

    def __init__(self, x, y):
        self.x = x
        self.y = y


class GrahamScan:

    def __init__(self, point_list):
        self.point_list = point_list
        self.hull_points = list()

    def compute_hull(self, point_list):
        pass

    def get_orientation(self, pivot, p1, p2):
        differences = ((p2.x - pivot.x)*(p1.y - pivot.y))-((p1.x - pivot.x)*(p2.y - pivot.y))
        return differences

    def get_lowest_x(self, point_list):
        start_point = point_list[0]
        min_x = start_point.x
        min_y = start_point.y
        for p in point_list[1:]:
            if p.x < min_x:
                min_x = p.x
                min_y = p.y
                start_point = p
            if p.x == min_x:
                if p.y < min_y:
                    min_x = p.x
                    min_y = p.y
                    start_point = p
        point = start_point
        return point

def convex_hull(answer_list, point_list):
    hull_points = list()
    graham = GrahamScan(point_list)

    #get the leftmost point
    point = graham.get_lowest_x(point_list)
    hull_points.append(point)

    other_point = None
    while other_point is not point:
        pi = None
        for p_one in point_list:
            if p_one is point:
                continue
            else:
                p1 = p_one
                break

        other_point = p1









def main():
    answer_list = list()
    case_num = int(sys.stdin.readline().strip())
    point_list = list()
    for c_num in range(case_num):
        frosh_num  = int(sys.stdin.readline())
        for f_num in range(frosh_num):
            x_position, y_position = map(float, sys.stdin.readline().split())
            point = Point(x_position, y_position)
            point_list.append(point)
    convex_hull(answer_list, point_list)






if __name__ =="__main__":
    main()
