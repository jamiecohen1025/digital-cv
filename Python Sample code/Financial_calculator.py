# write your code here
import math
import argparse
import sys

parser = argparse.ArgumentParser()
parser.add_argument('--type')
parser.add_argument('--payment')
parser.add_argument('--periods')
parser.add_argument('--interest')
parser.add_argument('--principal')
args = parser.parse_args()
args2 = sys.argv

if args.type == "annuity" or args.type == "diff":
    if args.type == "diff" and args.payment:
        print("Incorrect parameters")
    elif not args.interest:
        print("Incorrect parameters")
    elif len(args2) != 5:
        print("Incorrect parameters")
    elif not args.principal:
        if float(args.payment) < 0 or float(args.periods) < 0 or float(args.interest) < 0:
            print("Incorrect parameters")
        else:
            pmt = float(args.payment)
            n = float(args.periods)
            i_an = float(args.interest)

            # calculation
            i = i_an / (12 * 100)
            P = pmt / ((i * math.pow(1 + i, n)) / (math.pow(1 + i, n) - 1))

            n = int(n)
            if args.type == "diff":
                sum_ = 0
                for m in range(1, n + 1):
                    pmt_d = (P / n) + i * (P - ((P * (m - 1)) / n))
                    pmt_d = math.ceil(pmt_d)
                    sum_ += pmt_d
                    print(f'Month {m}: payment is {pmt_d}')
                overpayment = sum_ - P
                overpayment = int(overpayment)
                print()
                print(f'Overpayment = {overpayment}')
            else:
                total_paid = math.ceil(pmt * n)
                overpayment = total_paid - P
                overpayment = int(overpayment)
                P = int(P)
                print(f'Your loan principal = {P}!')
                print(f'Overpayment = {overpayment}')
    elif not args.payment:
        if float(args.periods) < 0 or float(args.interest) < 0 or float(args.principal) < 0:
            print("Incorrect parameters")
        else:
            P = float(args.principal)
            n = float(args.periods)
            i_an = float(args.interest)

            # calculation
            i = i_an / (12 * 100)
            pmt = P * ((i * math.pow(1 + i, n)) / (math.pow(1 + i, n) - 1))
            pmt = math.ceil(pmt)

            n = int(n)
            if args.type == "diff":
                sum_ = 0
                for m in range(1, n + 1):
                    pmt_d = (P / n) + i * (P - ((P * (m - 1)) / n))
                    pmt_d = math.ceil(pmt_d)
                    sum_ += pmt_d
                    print(f'Month {m}: payment is {pmt_d}')
                overpayment = sum_ - P
                overpayment = int(overpayment)
                print()
                print(f'Overpayment = {overpayment}')
            else:
                total_paid = math.ceil(pmt * n)
                overpayment = total_paid - P
                overpayment = int(overpayment)
                print(f'Your annuity payment = {pmt}!')
                print(f'Overpayment = {overpayment}')
    elif not args.periods:
        if float(args.payment) < 0 or float(args.interest) < 0 or float(args.principal) < 0:
            print("Incorrect parameters")
        else:
            P = float(args.principal)
            pmt = float(args.payment)
            i_an = float(args.interest)

            # calculation
            i = i_an / (12 * 100)
            x = pmt / (pmt - i * P)
            n = math.ceil(math.log(x, 1 + i))

            n = int(n)
            if args.type == "diff":
                sum_ = 0
                for m in range(1, n + 1):
                    pmt_d = (P / n) + i * (P - ((P * (m - 1)) / n))
                    pmt_d = math.ceil(pmt_d)
                    sum_ += pmt_d
                    print(f'Month {m}: payment is {pmt_d}')
                overpayment = sum_ - P
                overpayment = int(overpayment)
                print()
                print(f'Overpayment = {overpayment}')
            else:
                total_paid = math.ceil(pmt * n)
                overpayment = total_paid - P
                overpayment = int(overpayment)
                P = int(P)
                n_y = n // 12
                print(f'It will take {n_y} years to repay this loan!')
                print(f'Overpayment = {overpayment}')
    # print(f"P: {P}")
    # print(f"pmt: {pmt}")
    # print(f"i: {i}")
    # print(f"n: {n}")

else:
    print("Incorrect parameters")
