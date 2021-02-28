import sys


def heapify():
    pass


def build_min_heap(heap_array):
    for number in range(0, len(heap_array)):
        temp = number[0]
        number[len(heap_array)] = temp
        heapify()



def main():
    heap_array = [4, 9, 6, 17, 26, 8, 16, 19, 69, 32, 93, 55, 50]
    build_min_heap(heap_array)



if __name__ == "__main__":
    main()