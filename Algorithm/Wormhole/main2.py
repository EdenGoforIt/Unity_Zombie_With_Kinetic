def read_test_case():
    n, m = (int(i) for i in input().split())
    edge_list = []
    for i in range(m):
        edge_list.append([int(i) for i in input().split()])
    return n, m, edge_list

def bellman_ford(n, m, edge_list):
    dist = [None] * n
    dist[0] = 0
    for i in range(n - 1):
        changed = False
        for x, y, weight in edge_list:
            if dist[x] is not None and (dist[y] is None or dist[y] > dist[x] + weight):
                    dist[y] = dist[x] + weight
                    changed = True
        if not changed:
            return False
    for x, y, weight in edge_list:
        if dist[y] > dist[x] + weight:
            return True
    return False

if __name__ == '__main__':
    for i in range(int(input())):
        print('possible' if bellman_ford(*read_test_case()) else 'not possible')