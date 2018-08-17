import math 

def partition(A,p,r): 
    indice_especial = p + round(math.log1p((r-p)**2))
    #indice_especial = A[r]
    temp = A[indice_especial]
    A[len(A) - 1] = A [indice_especial] 
    A[indice_especial] = temp
    j = p - 1 
    for i in range(p,r-1):
        if A[i] <= A[r]:
            j += 1 
            temp = A[j]
            A[j] = A[i]
            A[i] = temp
    temp = A[r]
    A[r] = A[j + 1]
    A[j + 1] = temp 
    return(j + 1)

def quicksort(A, p, r):
    if p < r:
        q = partition(A,p,r)
        quicksort(A, p, q - 1)
        quicksort(A, q + 1, r)

unsorted_array = [5,10,15,32,55,21,40,2,3,76,89,28,9,7]
#print(partition(unsorted_array,0,(len(unsorted_array)-1)))
quicksort(unsorted_array,0,(len(unsorted_array)-1))
print(unsorted_array)
