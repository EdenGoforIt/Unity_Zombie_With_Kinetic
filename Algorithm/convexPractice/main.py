import anchor as anchor
from matplotlib import pyplot
from random import randint
from math import atan2


def create_points(ct, min=0, max = 50):
    return [[randint(min, max), randint(min, max)] for _ in range(ct)]

def scatter_plot(coords, convex_hull = None):
    xs, xy = zip(*coords)
    pyplot.scatter(xs, xy)
    if convex_hull!=None:
        for i in range(1, len(convex_hull)+1):
            if i ==len(convex_hull): i =0
            c0 = convex_hull[i-1]
            c1 = convex_hull[i]
            pyplot.plot((c0[0], c1[0]), (c1[0], c1[1]), 'r')

    pyplot.show()

def polar_angle(p0, p1=None):
    if p1 == None:
        p1 = anchor
    y_span = p0[1]-p1[1]
    x_span = p0[0]-p1[0]
    return atan2(y_span, x_span)


def distance(p0, p1=None):
    if p1 == None:
        p1 = anchor
    y_span = p0[1]-p1[1]
    x_span = p0[0]-p1[0]
    return y_span**2 + x_span**2

def det(p1, p2, p3):
    return (p2[0]-p1[0])*(p3[1]-p1[1])-(p2[1]-p1[1])*(p3[0]-p1[0])

def quicksort(a):
    if len(a)<=1: return a
    smaller, equal, larger = [],[],[]
    piv_ang=polar_angle(a[randint(0, len(a)-1)])
    for pt in a:
        pt_ang = polar_angle(pt)
        if pt_ang<piv_ang: smaller.append(pt)
        elif pt_ang ==piv_ang: equal.append(pt)
        else:
            larger.append(pt)
    return quicksort(smaller)+sorted(equal, key=distance)+quicksort(larger)

def graham_scan(points, show_progress= False):
    global anchor
    min_idx = None
    for i,(x,y) in enumerate(points):
        if min_idx == None or y<points[min_idx][1]:
            min_idx=i
        if y==points[min_idx][1] and x<points[min_idx][0]:
            min_idx=i
            


