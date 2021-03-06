﻿using System;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Enum;

namespace SubstrateNetApi.Model.Types.Struct
{
    public class Phase : StructType
    {
        public override string Name() => "Phase";

        private int _size;
        public override int Size() => _size;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            PhaseState = new EnumType<PhaseState>();
            PhaseState.Decode(byteArray, ref p);

            if (PhaseState.Value == Enum.PhaseState.None)
            {
                ApplyExtrinsic = new ApplyExtrinsic();
                ApplyExtrinsic.Decode(byteArray, ref p);
            }

            _size = p - start;
        }

        public ApplyExtrinsic ApplyExtrinsic { get; set; }
        public EnumType<PhaseState> PhaseState { get; set; }
    }
}