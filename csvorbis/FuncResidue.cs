/* JOrbis
 * Copyright (C) 2000 ymnk, JCraft,Inc.
 *  
 * Written by: 2000 ymnk<ymnk@jcaft.com>
 *   
 * Many thanks to 
 *   Monty <monty@xiph.org> and 
 *   The XIPHOPHORUS Company http://www.xiph.org/ .
 * JOrbis has been based on their awesome works, Vorbis codec.
 *   
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Library General Public License
 * as published by the Free Software Foundation; either version 2 of
 * the License, or (at your option) any later version.
   
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Library General Public License for more details.
 * 
 * You should have received a copy of the GNU Library General Public
 * License along with this program; if not, write to the Free Software
 * Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
 */

using System;
using csogg;

abstract class FuncResidue
{
	public static FuncResidue[] residue_P={new Residue0(),
											  new Residue1(),
											  new Residue2()};

	public abstract void pack(Object vr, csBuffer opb);
	public abstract Object unpack(Info vi, csBuffer opb);
	public abstract Object look(DspState vd, InfoMode vm, Object vr);
	public abstract void free_info(Object i);
	public abstract void free_look(Object i);
	public abstract int forward(Block vb,Object vl, float[][] fin, int ch);

	public abstract int inverse(Block vb, Object vl, float[][] fin, int[] nonzero,int ch);}
