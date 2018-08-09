#JOSÉ ALEJANDRO GUZMÁN ZAMORA
import math 

possible_heap = [16,14,10,8,7,9,3,2,4,1]

def es_heap(sequence):
    #inserto un 0 en el índice 0 para facilitar el indexado 
    sequence.insert(0,0)
    for i in range(1,math.floor(len(sequence)/2)):
        if ((2 * i) + 1) <= len(sequence):
            if (sequence[2 * i] > sequence[i]) or (sequence[(2 * i) + 1] > sequence[i]):
                return False 
        else:
            if (sequence[2 * i] > sequence[i]):
                return False 
            
    return True

print(es_heap(possible_heap))