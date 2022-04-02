import asm

#from asm.instuctions import mov, shl, shr
#from asm.function import Function
#from asm.registers import eax, ebx
#from asm.variable import Variable

a = asm.variable.Variable(dtype='long int')
out = asm.variable.Variable(dtype='int', value=1)

f = Function([mov(asm.registers.eax, a),
              asm.instuctions.shl(asm.registers.eax, 4),
              asm.instuctions.shr(asm.registers.eax, 6),
              asm.instuctions.mov(out, asm.registers.eax)])

f.compile(input_vars=[a], output_var=out)

print(f(1))
print(f(356))